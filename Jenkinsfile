// codename: helix

// на агента потрібно встановити dotnet sdk, щоб виконати цю побудову

pipeline {
    agent any

    stages {
        stage('Restore .NET Dependencies') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish --configuration Release --output '
            }
        }
    }
}
