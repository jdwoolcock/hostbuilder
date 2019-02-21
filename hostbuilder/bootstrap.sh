systemctl stop --user hostbuilder.service
sudo dotnet publish hostbuilder.csproj -o /opt/daemons/hostbuilder/
cp hostbuilder.service ~/.config/systemd/user/
systemctl --user daemon-reload
systemctl start --user hostbuilder.service
systemctl status --user hostbuilder.service