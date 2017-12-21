Containo
===========================

[![Build Status](https://travis-ci.org/tomkerkhove/containo.svg?branch=master)](https://travis-ci.org/tomkerkhove/containo)[![License](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/CoditEU/application-insights-connector/blob/master/LICENSE)

Containo is a fictious company that is building a product that provides a catalog of products to buy that 3rd parties can consume.

The platform is running .NET Core APIs that are running in Docker containers exposed via Kong as an API gateway.

![Docker](./media/docker.png)![Kong](./media/kong.png)

# Architecture
![Architecture](./docs/architecture.png)

# Installation
In order to run this sample you'll need to prepare your environment:

1. Create a new docker network - `docker network create api-ecosystem`
2. Install [Kong](https://getkong.org/install/docker) that is using Cassandra or PostgreSQL as a data store. ([Docker image](https://store.docker.com/images/kong))
3. Optionally, install [Konga](https://github.com/pantsel/konga#production-docker-image), which is a 3rd party tool, that gives you a Management UI. ([Docker image](https://store.docker.com/community/images/pantsel/konga))
4. Deploy the containo API via Docker Compose in `src/docker-compose.yml`
5. Create an API in Kong
```
curl -i -X POST \
  --url http://localhost:8001/apis/ \
  --data 'name=containo.api' \
  --data 'uris=//containo' \
  --data 'upstream_url=http://containo:80/api'
```
6. Start consuming the API
```
curl -i -X GET --url localhost:8000/containo/records
```

**Important** - All containers need to be in the `api-ecosystem network`.

# License Information
This is licensed under The MIT License (MIT). Which means that you can use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the web application. But you always need to state that Codit is the original author of this web application.