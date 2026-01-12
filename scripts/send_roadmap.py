import os
import requests
import json

file_path = 'README.md'

try:
    with open(file_path, 'r', encoding='utf-8') as f:
        lines = f.readlines()
except FileNotFoundError:
    print("README.md file not found!")
    exit(1)

description = ""
found_header = False

for line in lines:
    line_stripped = line.strip()
    
    if "## 🔮 Roadmap" in line_stripped:
        found_header = True
        continue
    
    if found_header and line_stripped.startswith("##"):
        break
    
    if found_header:
        formatted_line = line_stripped.replace("[x]", "✅").replace("[ ]", "⬜")
        
        if formatted_line:
            description += formatted_line + "\n"

webhook_url = os.environ['DISCORD_WEBHOOK']

data = {
    "username": "geetRPCS GitHub",
    "avatar_url": "https://i.ibb.co/GfbNxhP2/geetrpcs-animated-logo.gif", 
    "embeds": [
        {
            "title": "🔮 Update Roadmap!",
            "description": description,
            "color": 5814783,
            "footer": {
                "text": "Otomatis update dari GitHub"
            }
        }
    ]
}

response = requests.post(webhook_url, json=data)

if response.status_code == 204:
    print("Embed sent successfully!")
else:
    print(f"Failed to send: {response.status_code}, {response.text}")
