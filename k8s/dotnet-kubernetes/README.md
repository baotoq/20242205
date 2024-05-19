# eShopLite

```
dotnet publish /p:PublishProfile=DefaultContainer -p ContainerImageTags='"v1.0.1"'
```

docker tag store bao2703/storeimage
docker tag products bao2703/productservice

docker push bao2703/storeimage
docker push bao2703/productservice
