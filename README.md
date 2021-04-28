# Azure Function triggered by Blob storage
This project demonstrates an Azure Function that run when an image in uploaded in the Blob storage.
The function resize the image then save it back to the Blob storage.

# Local development
## Prerequisite
* Visual Studio (Make sure you have the “Azure Workload” installed)
* Azure account

## Getting started
Create a storage account in Azure, add two containers :
* "normal-size": will store the images to be resized.
* "reduced-size": will store the images that have been resized.

Copy the connection string of the Blobstorage to local.settings.json
 ``"BlobConnectionString": ""``
