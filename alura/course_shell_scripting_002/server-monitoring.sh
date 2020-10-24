#!/bin/bash

response=$(curl -w %{http_code} --output /dev/null --silent localhost)

echo $response
