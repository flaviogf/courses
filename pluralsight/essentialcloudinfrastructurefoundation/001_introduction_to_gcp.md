# Introduction to GCP

```sh
export MY_UUID=$(python3 -c 'import uuid; print(uuid.uuid4())')

gsutil mb "gs://$MY_UUID"

lsb_release -d > release.txt

gsutil cp release.txt "gs://$MY_UUID"

gcloud compute regions list

export INFRACLASS_REGION=us-central1

mkdir infraclass

touch infraclass/config

echo INFRACLASS_REGION=$INFRACLASS_REGION >> infraclass/config

export INFRACLASS_PROJECT_ID=$DEVSHELL_PROJECT_ID

echo INFRACLASS_PORJECT_ID=$INFRACLASS_PROJECT_ID >> infraclass/config

source infraclass/config

echo $INFRACLASS_REGION

echo $INFRACLASS_PROJECT_ID
```

```sh
sudo /opt/bitnami/ctlscript.sh stop

sudo /opt/bitnami/ctlscript.sh restart
```
