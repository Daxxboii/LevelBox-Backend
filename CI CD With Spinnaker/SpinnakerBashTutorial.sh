
echo “Enter MANAGED AWS Account ID:”
read AWS_ACCOUNT_ID

echo “Enter Aws User Key:”
read AWS_User_Key

curl -O https://raw.githubusercontent.com/spinnaker/halyard/master/install/debian/InstallHalyard.sh


sudo bash InstallHalyard.sh


hal -v


hal config provider aws edit --access-key-id $AWS_User_Key --secret-access-key 


hal config provider aws account add AWSACCOUNT --account-id $AWS_ACCOUNT_ID --assume-role role/spinnakerManaged


hal config provider aws account edit AWSACCOUNT --regions us-east-1


hal config provider aws enable


hal config provider ecs account add ECSACCOUNT --aws-account AWSACCOUNT


hal config provider ecs enable


hal config storage s3 edit --access-key-id $AWS_User_Key --secret-access-key
hal config storage edit --type s3


hal config version edit --version 1.27.3

echo "host: 0.0.0.0" | sudo tee /home/spinnaker/.hal/default/service-settings/gate.yml /home/spinnaker/.hal/default/service-settings/deck.yml
    
sudo hal deploy apply

sudo hal deploy apply


sudo hal deploy connect
