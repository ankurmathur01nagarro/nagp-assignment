# NAGP Assignment Details
As per the assignment requirements i have created a 3-tier application.
1. UI (Svelte v5)
2. API (ASP.NET Core v9 WebAPI)
3. Database (Postgres v17)

The application is about storing movies, and it will display the ratings as well as year of release. For now we can list movies and add new movies in the database. I have not made it fully featured as this was not the focus of the assignment. I have used IMDb like theme to make it look good. (with some help of AI 😁)

This is how the application looks:

![alt text](/images/image.png)

## Deployment Architecture
To deploy on kubernetes (Google Kubernetes Engine), i have created a helm chart package and used it to deploy and manage the releases on k8s. I have created the following resources on kubernetes:
1. Postgres: **StatefulSet with 1 pod replica** with persistent storage and created a **Headless** service for it, so that it can be accessed using CoreDNS (DNS inside K8s).
   1. StatefulSet - 1 Pod
   2. **Persistent Volume Claim** (Using standard and default Google Cloud storageClass)
   3. Headless Service
2. Web API: Deployment with **2 pod replicas** and a ClusterIP service for interaction with the Ingress controller.
3. Application UI: Deployment with **4 pod replicas** and a ClusterIP services for interaction with the Ingress controller.
4. Ingress: Using a standard nginx based Ingress Controller (**ingress-nginx**), using Fan-Out backend topology,
   1. Path (/): Redirect to the UI app service
   2. Path (/api): Redirect to the Web API
   3. _*Some more routes for utility purposes_
   
   _The main reason to use ingress-nginx here is that the default GKE Ingress has some limitations around CORS and SPA like handling._
5. **ConfigMaps** for storing API's base url for use in frontend application.
6. **Secrets** for storing postgres password and connection string for dotnet webapi applications.

## Folder Structure
The folder structure for this assignment code is as follows:
```
.
├── api/                           # .NET API Project
│   ├── NAGP.Api/                 # Main API Project
│   ├── NAGP.Api.Data/            # Data Access Layer
│   └── NAGP.Api.MigrationJob/    # Database Migration Job
├── app/                          # Svelte Frontend Application
│   ├── src/                      # Source code
│   │   ├── lib/                  # Library components
│   │   └── routes/               # Application routes
│   └── static/                   # Static assets
└── deploy/                       # Kubernetes deployment files
    └── nagp-assignment/          # Helm chart for deployment
```

## Building docker images from Source
There are 3 docker images to build from source. Each layer/tier is containerized using dockerfile, and uploaded to Docker Hub, and accessed publically here: [Ankur Mathur Docker Hub](https://hub.docker.com/repositories/ankurmathur01nagarro). There are 3 docker images and 1 public image for DB:
1. Database - **postgres:v17.5-alpine**
2. Application UI - **ankurmathur01nagarro/nagp-app**
3. API Layer - **ankurmathur01nagarro/nagp-app-api**
4. API Database Migration - **ankurmathur01nagarro/nagp-api-migration** (for schema changes and initial data migration)

> **NOTE**:<br>
 I have created a batch utility for automating these tasks on windows but on any other platform we might need to build images manually using custom commands. Name of the batch file is:
> ```bash
> build-dockerimages-deploy.bat
> ```
> I used a WSL2 environment on windows 11, so the commands in here are targeted for wsl directly. But a reference can be taken from here.



The application is deployed/installed/upgraded using helm chart. I have created a helm chart at
I have also created a utility for automatic docker image creation and 