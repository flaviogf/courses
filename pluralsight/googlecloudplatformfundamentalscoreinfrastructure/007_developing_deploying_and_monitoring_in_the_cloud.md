# Developing, Deploying and Monitoring in the Cloud

```sh
export MY_ZONE=us-central1-a

gsutil cp gs://cloud-training/gcpfcoreinfra/mydeploy.yaml mydeploy.yaml

sed -i "s/PROJECT_ID/$DEVSHELL_PROJECT_ID/" mydeploy.yaml

sed -t "s/ZONE/$MY_ZONE/" mydeploy.yaml

cat mydeploy.yaml

gcloud deployment-manager deployments create my-first-depl --config mydeploy.yaml

gcloud deployment-manager deployments update my-first-depl --config mydeploy.yaml

dd if=/dev/urandom | gzip -9 >> /dev/null &

curl -sSO https://dl.google.com/cloudagents/install-monitoring-agent.sh
sudo bash install-monitoring-agent.sh

curl -sSO https://dl.google.com/cloudagents/install-logging-agent.sh
sudo bash install-logging-agent.sh

kill %1
```

```yaml
# mydeploy.yaml

resources:
- name: my-vm
  type: compute.v1.instance
  properties:
    zone: ZONE
    machineType: zones/ZONE/machineTypes/n1-standard-1
    metadata:
      items:
      - key: startup-script
        value: "apt-get update"
    disks:
    - deviceName: boot
      type: PERSISTENT
      boot: true
      autoDelete: true
      initializeParams:
        sourceImage: https://www.googleapis.com/compute/v1/projects/debian-cloud/global/images/debian-9-stretch-v20201216
    networkInterfaces:
    - network: https://www.googleapis.com/compute/v1/projects/PROJECT_ID/global/networks/default
      accessConfigs:
      - name: External NAT
        type: ONE_TO_ONE_NAT
```
