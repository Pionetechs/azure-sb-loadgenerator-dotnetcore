#!/bin/bash

CONNECTION_STRING="Endpoint=sb://vb-core-pftest01-eventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Jq3mQcmCF1KsOfqIzxeHOjcev4J2m22uIdoY1JOdKow=" 
ENTITY_NAME="v1_receiver_signals"

dotnet loadgenerator.dll -c $CONNECTION_STRING -t 366 --terminate-after 300 -b 1 -n $ENTITY_NAME

