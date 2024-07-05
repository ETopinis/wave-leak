local localPlayer;

while true do
	localPlayer = game:GetService("Players").LocalPlayer;
	if localPlayer then
		break;
	end
	task.wait(0.25);
end

local sockets, connections = {}, {
	clientInformation = {
		port = 6001,
		paths = { "transferClientInformation" }
	}
}

for _, conn in connections do
	for _, path in conn.paths do
		sockets[path] = WebSocket.connect("ws://localhost:" .. conn.port .. "/" .. path)
	end
end

sockets.transferClientInformation:Send(game:GetService("HttpService"):JSONEncode({
	Username = localPlayer.Name,
	UserId = localPlayer.UserId,
	ProcessId = getprocessid(),
	JobId = game.JobId
}));

sockets.transferClientInformation:Close();