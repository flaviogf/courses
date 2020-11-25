#!/bin/bash

echo "What's tomorrow's weather going to be like?"
read weather
case $weather in
  sunny | warm ) echo "Nice! I love it when it's $weather"
  ;;
  cloudy | cool ) echo "Not bad...$weather is ok, too"
  ;;
  rainy | cold ) echo "Yuk! $weather weather is depressing"
  ;;
  * ) echo "Sorry I'm not familiar with that weather system"
  ;;
esac
exit 0
