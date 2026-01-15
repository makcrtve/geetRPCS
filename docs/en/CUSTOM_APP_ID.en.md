## 🆔 Tutorial: Customizing RPC Name (Custom Application ID)

By default, your Discord status will display: **"Playing geetRPCS"**.
This feature allows you to change it to anything you want, for example: **"Playing Working Hard"**, **"Playing Just Chilling"**, or your own brand name.

### ⚠️ Important Warning (Read First!)

Discord Rich Presence works by binding **Images (Assets)** to a specific **Application ID**.
If you switch the ID to your own personal ID:

1.  **The RPC Name will change** to whatever you want (Awesome! 🎉).
2.  **The Images (App Logos) will DISAPPEAR** (Blank ⬜), because your new ID does not have those images uploaded yet.

**Solution:** You must re-upload the necessary images to your own portal (explained in Step 3).

---

### Step 1: Create a Discord Application

1.  Open the [Discord Developer Portal](https://discord.com/developers/applications) and log in.
2.  Click the **New Application** button in the top right corner.
3.  **Name**: Enter the name you want to display on your Discord status (Example: *"Secret Project"*).
4.  Click **Create**.
5.  In the left menu, click **OAuth2** (or on the General Information page), and copy the **Application ID** (Client ID).

### Step 2: Input into geetRPCS

1.  Open **geetRPCS** (make sure it is running in the System Tray).
2.  Right-click the Tray icon → select **🆔 Change Application ID...**
3.  Paste the **Application ID** you copied earlier.
4.  Click **Save**.
5.  The application will reload automatically. Your Discord status name has now changed!

---

### Step 3: Fixing Missing Images (Optional)

If you want application icons (like the FL Studio logo, VS Code, etc.) to appear, you must upload them to the new Discord Application you just created.

1.  Go back to the [Discord Developer Portal](https://discord.com/developers/applications).
2.  Select your application.
3.  In the left menu, select **Rich Presence** → **Art Assets**.
4.  Click **Add Images**.
5.  Upload the images you want to use.
    * *Tip: You can use the original geetRPCS asset pack if provided by the developer.*

6.  **IMPORTANT:** Change the Asset Name so it matches **EXACTLY** with the "Key" used in `apps.json`.

**Example:**
If `apps.json` contains:

```json
"largeKey": "flstudio",
"smallKey": "geetrpcs-small"

```

Then in the Developer Portal, you must name your images:

* FL Studio logo image → name it `flstudio`
* Small logo image → name it `geetrpcs-small`

7. Wait about 5-10 minutes (Discord takes time to update assets).
8. Restart geetRPCS. The images should reappear!

---

### 💡 Additional Tips

* You can create custom Buttons via the `config.json` file.
* If you only want to change the name and don't care about the images, you only need to do **Steps 1 & 2**.
