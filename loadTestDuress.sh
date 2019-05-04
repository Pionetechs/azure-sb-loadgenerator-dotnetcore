#!/bin/bash

CONNECTION_STRING="Endpoint=sb://vb-core-pftest02-eventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=M9FTZ3gK14E6AgCNPMEhq2ZDooDje98cQcNl3WA9yEQ=" 
ENTITY_NAME="v1_staff_duress"

dotnet loadgenerator.dll -c $CONNECTION_STRING -t 750 --terminate-after 30 -b 1 -n $ENTITY_NAME

