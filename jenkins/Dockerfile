FROM  mcr.microsoft.com/dotnet/sdk:5.0

ENV WORKING_DIR=/usr/app/src/

ENV PATH="${PATH}:/root/.dotnet/tools:/opt/jdk17/bin"

ENV JAVA_HOME=/opt/jdk17
 
WORKDIR ${WORKING_DIR}
 
 
RUN wget https://download.java.net/openjdk/jdk17/ri/openjdk-17+35_linux-x64_bin.tar.gz\

     && tar xvf openjdk-17+35_linux-x64_bin.tar.gz \

    && mv jdk-17*/ /opt/jdk17 \

    && rm -f openjdk-17+35_linux-x64_bin.tar.gz
 
RUN apt update \

&& apt install -y gnupg make
 
 
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
 

RUN dotnet tool install --global coverlet.console --version 1.7.2
 
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - && \

    apt-get install -y nodejs

RUN dotnet tool install --global minver-cli --version 2.3.1