# Containers in the Cloud

```sh
export MY_ZONE=us-central1-a

gcloud container cluster create webfrontend --zone $MY_ZONE --num-nodes 2

kubectl version

kubectl create deploy nginx --image=nginx:1.17.10

kubectl get pods

kubectl expose deployment nginx --port 80 --type LoadBalancer

kubectl get services

kubectl scale deployment nginx --replicas 3

kubectl get pods

kubectl get services
```
