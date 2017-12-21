Containo
===========================

[![Build Status](https://travis-ci.org/tomkerkhove/containo.svg?branch=master)](https://travis-ci.org/tomkerkhove/containo)[![License](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/CoditEU/application-insights-connector/blob/master/LICENSE)

Containo is a sandbox to try out new technologies such as Docker, .NET Core, etc.

![Docker](./media/docker.png)

# Installation
In order to run this sample you'll need to prepare your environment:

1. Create a new docker network with `docker network create api-ecosystem`
2. Install [Kong](https://getkong.org/install/docker) that is using Cassandra or PostgreSQL as a data store. ([Docker image](https://store.docker.com/images/kong))
3. Optionally, install [Konga](https://github.com/pantsel/konga#production-docker-image), which is a 3rd party tool, that gives you a Management UI. ([Docker image](https://store.docker.com/community/images/pantsel/konga))
4. Deploy the containo API via Docker Compose in `src/docker-compose.yml`

# License Information
This is licensed under The MIT License (MIT). Which means that you can use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the web application. But you always need to state that Codit is the original author of this web application.