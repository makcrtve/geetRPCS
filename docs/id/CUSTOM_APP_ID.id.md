## 🆔 Tutorial: Mengubah Nama RPC (Custom Application ID)

Secara default, status Discord Anda akan tertulis: **"Playing geetRPCS"**.
Fitur ini memungkinkan Anda mengubahnya menjadi apa saja, misalnya: **"Playing Sedang Nugas"**, **"Playing Gabut"**, atau nama brand Anda sendiri.

### ⚠️ Peringatan Penting (Baca Dulu!)

Discord Rich Presence bekerja dengan mengikat **Gambar (Assets)** ke **Application ID**.
Jika Anda mengganti ID ke ID milik Anda sendiri:

1. **Nama RPC akan berubah** sesuai keinginan Anda (Mantap! 🎉).
2. **Gambar (Logo aplikasi/software) akan HILANG** (Blank ⬜), karena ID baru Anda belum memiliki gambar-gambar tersebut.

**Solusi:** Anda harus mengupload ulang gambar yang dibutuhkan ke portal Anda sendiri (dijelaskan di Langkah 3).

---

### Langkah 1: Buat Aplikasi di Discord

1. Buka [Discord Developer Portal](https://discord.com/developers/applications) dan login.
2. Klik tombol **New Application** di pojok kanan atas.
3. **Name**: Masukkan nama yang ingin Anda tampilkan di status Discord (Contoh: *"Project Rahasia"*).
4. Klik **Create**.
5. Di menu sebelah kiri, klik **OAuth2** (atau di halaman General Information), salin **Application ID** (Client ID).

### Langkah 2: Masukkan ke geetRPCS

1. Buka **geetRPCS** (pastikan sudah berjalan di System Tray).
2. Klik kanan ikon Tray → pilih **🆔 Change Application ID...**
3. Paste **Application ID** yang tadi Anda salin.
4. Klik **Simpan**.
5. Aplikasi akan reload otomatis. Sekarang status Discord Anda sudah berubah namanya!

---

### Langkah 3: Memperbaiki Gambar yang Hilang (Opsional)

Jika Anda ingin icon aplikasi (seperti logo FL Studio, VS Code, dll) tetap muncul, Anda harus menguploadnya ke aplikasi Discord yang baru Anda buat tadi.

1. Kembali ke [Discord Developer Portal](https://discord.com/developers/applications).
2. Pilih aplikasi Anda.
3. Di menu kiri, pilih **Rich Presence** → **Art Assets**.
4. Klik **Add Images**.
5. Upload gambar-gambar yang ingin Anda gunakan.
* *Tip: Anda bisa mengambil aset gambar asli geetRPCS jika disediakan developernya.*


6. **PENTING:** Ubah nama aset (Asset Name) agar **SAMA PERSIS** dengan "Key" yang digunakan di `apps.json`.

**Contoh:**
Jika di `apps.json` tertulis:

```json
"largeKey": "flstudio",
"smallKey": "geetrpcs-small"

```

Maka di Developer Portal, Anda harus menamai gambar Anda:

* Gambar logo FL Studio → beri nama `flstudio`
* Gambar logo kecil → beri nama `geetrpcs-small`

7. Tunggu sekitar 5-10 menit (Discord butuh waktu untuk update aset).
8. Restart geetRPCS. Gambar akan muncul kembali!

---

### 💡 Tips Tambahan

* Anda bisa membuat tombol (Button) kustom melalui file `config.json`.
* Jika Anda hanya ingin mengubah nama tanpa peduli gambar, Anda cukup lakukan **Langkah 1 & 2** saja.
