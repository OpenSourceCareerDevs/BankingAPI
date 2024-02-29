#Jenkins base image.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build

RUN echo 'deb http://ppa.launchpad.net/ansible/ansible/ubuntu trusty main' >> /etc/apt/sources.list \
&& apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 93C4A3FD7BB9C367 \
&& apt update \
&& apt install -y ansible sshpass

RUN apt install -y python-pip && \
pip install docker


RUN apt-get install -y apt-transport-https ca-certificates curl unzip software-properties-common && \
    curl -fsSL https://download.docker.com/linux/debian/gpg | apt-key add - && \
    add-apt-repository \
       "deb [arch=amd64] https://download.docker.com/linux/debian \
       $(lsb_release -cs) \
       stable" && \
    apt update && \
    apt install -y docker-ce docker-ce-cli containerd.io

RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash -

RUN apt install nodejs && \
    npm install -g npm@10.2.1