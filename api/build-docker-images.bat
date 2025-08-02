@echo off
wsl docker build -f Dockerfile.api -t ankurmathur01nagarro/nagp-api:v1.0.5 .
wsl docker push ankurmathur01nagarro/nagp-api:v1.0.5

wsl docker build -f Dockerfile.migration -t ankurmathur01nagarro/nagp-api-migration:v1.0.5 .
wsl docker push ankurmathur01nagarro/nagp-api-migration:v1.0.5