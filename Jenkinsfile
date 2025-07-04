pipeline {
    agent any

    environment {
        GIT_COMMIT_HASH = sh(script: "git rev-parse --short HEAD", returnStdout: true).trim()
    }

    stages {

        //!!!
        //Resore, Build and Publish stages are commented, as they are present in Dockerfile
        //

        // stage('Restore .NET Dependencies') {
        //     steps {
        //         sh 'dotnet restore'
        //     }
        // }

        // stage('Build') {
        //     steps {
        //         sh 'dotnet build --configuration Release'
        //     }
        // }

        // stage('Publish') {
        //     steps {
        //         sh 'dotnet publish --configuration Release'
        //     }
        // }

        stage('Create Docker image') {
            // when {
            //     expression {
            //         return env.GIT_BRANCH && (env.GIT_BRANCH.contains("snapshot-") || env.GIT_BRANCH.contains("release-"))
            //     }
            // }
            steps {
                sh "docker build -t helix:${GIT_COMMIT_HASH} ."
            }
        }

        stage('Push Docker image') {
            // when {
            //     expression {
            //         return env.GIT_BRANCH && (env.GIT_BRANCH.contains("snapshot-") || env.GIT_BRANCH.contains("release-"))
            //     }
            // }
            steps {
                script {
                    sh "docker tag helix:${GIT_COMMIT_HASH} viyd/military:helix-${GIT_COMMIT_HASH}"
                    withCredentials([string(credentialsId: 'DOCKERHUB', variable: 'DOCKERHUB')]) {
                        sh "echo $DOCKERHUB | docker login -u viyd --password-stdin"
                        sh "docker push viyd/military:helix-${GIT_COMMIT_HASH}"
                    }
                }
            }
        }

    }
}
