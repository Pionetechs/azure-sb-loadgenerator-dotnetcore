#!/bin/bash

CONNECTION_STRING="Endpoint=sb://vb-core-pftest02-eventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=M9FTZ3gK14E6AgCNPMEhq2ZDooDje98cQcNl3WA9yEQ=" 
ENTITY_NAME="v1_receiver_battery"

dotnet loadgenerator.dll -c $CONNECTION_STRING -t 366 --terminate-after 60 -b 1 -n $ENTITY_NAME

