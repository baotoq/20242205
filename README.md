# 2024-22-05 Presentation

1. k8s overview
```
kubectl port-forward --namespace default svc/helloworld 8222:8222
```
2. helm overview
3. kustomize overview
```
kustomize build helloworld | kubectl apply -f -
```
4. .net aspire overview
```
~/.dotnet/tools/aspirate generate --disable-secrets
```


https://learn.microsoft.com/en-us/training/modules/dotnet-deploy-microservices-kubernetes/