pipeline{
    agent any

    stages{
        stage('Initial_cleanup'){
            steps {

                dir ("${WORKSPACE}"){
                    deleteDir()
                }
                
            }
        }
        stage('checkout'){
            steps {
                script {
                    sh "git clone https://github.com/DevProject03/backendproj"
                }
                
            }
        }
        stage('Restore packages') {
            steps {
                script{
                    sh "cd backendproj && dotnet restore BankingAPIs"
                }
            }
        }
        stage('Unit test'){
            steps{
                script{
                    sh "cd backendproj && dotnet test BankingAPIs/BankingAPIs.Test/ControllerUnitTest"
                }
            }
        }

        stage('Build'){
            steps{
                script{
                    sh "cd backendproj && dotnet build BankingAPIs"
                }
            }
        }
         stage('Publish'){
            steps{
                script{
                    sh "cd backendproj && dotnet publish BankingAPIs"
                 }
            }
        }
    
        stage('Build image'){
            steps{
                script{
                    sh "cd backendproj && docker build -t lizdockerhub/dotnetapp ."
                }
            }
        }
        stage('Push image'){
            steps{
                script{
                    sh "docker login -u ${env.username} -p ${env.password}"
                    sh "docker push lizdockerhub/dotnetapp"
                }
                
            }
        }
        stage('Logout'){
            steps{
                script{
                    sh "docker logout"
                }
                
            }
        }
    }   
    
}
