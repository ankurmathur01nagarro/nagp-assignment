@echo off
set VERSION=v1.1.5
wsl docker build -f ./api/Dockerfile.api -t ankurmathur01nagarro/nagp-api:%VERSION% ./api
wsl docker push ankurmathur01nagarro/nagp-api:%VERSION%

wsl docker build -f ./api/Dockerfile.migration -t ankurmathur01nagarro/nagp-api-migration:%VERSION%  ./api
wsl docker push ankurmathur01nagarro/nagp-api-migration:%VERSION%

wsl docker build -f ./app/Dockerfile -t ankurmathur01nagarro/nagp-app:%VERSION% ./app
wsl docker push ankurmathur01nagarro/nagp-app:%VERSION%

helm upgrade --install nagp-assignment .\deploy\nagp-assignment\ --namespace nagp-assignment --create-namespace --set imgVersion=%VERSION% --set postgres.adminPassword=password
echo "Deployment completed successfully."
