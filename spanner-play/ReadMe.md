


### Authenticate via Docker Container

Use the official Google Cloud CLI Docker image to generate your Application Default Credentials and save to the local host home directory.

When running inside the container without access to your host's web browser, use the --no-browser flag to complete the OAuth flow.

```bash
docker run -ti --rm --network host \
-v ~/.config/gcloud:/root/.config/gcloud \
gcr.io/google.com/cloudsdktool/google-cloud-cli:583.0.0-slim \
gcloud auth application-default login
```

Click on the link and complete the OAuth flow in your browser. Copy the generated authentication code and paste it into the terminal.

When your application connects to Spanner using your personal Google account via Application Default Credentials (ADC), Google Cloud requires a designated "quota project" to
track API usage and rate limits. Without it, the Spanner API outright rejects the connection with a PermissionDenied error. To set the quota project, run:

```bash
docker run -ti --rm --network host \
-v ~/.config/gcloud:/root/.config/gcloud \
gcr.io/google.com/cloudsdktool/google-cloud-cli:583.0.0-slim \
gcloud auth application-default set-quota-project PROJECT_ID_HERE
```

Note that as we ran the command in the terminal, root will own the files.  To fix:

```bash
sudo chown -R $USER:$USER ~/.config/gcloud
```

Verify the credentials file by checking all the fields are populated and that it says `authorized_user`
```bash
cat ~/.config/gcloud/application_default_credentials.json
```



