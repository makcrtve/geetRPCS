<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="400"/>
</p>

<h1 align="center">🔒 Kebijakan Privasi</h1>
<p align="center">
  <b>geetRPCS - Discord Rich Presence Client</b><br/>
  <sub>Terakhir diperbarui: 4 Januari 2026</sub>
</p>

---

## 📋 Ringkasan

**geetRPCS** menghormati privasi penggunanya. Dokumen ini menjelaskan bagaimana aplikasi kami menangani data dan informasi pengguna.

> **TL;DR:** geetRPCS **TIDAK** mengumpulkan, menyimpan, atau mengirim data pribadi kamu ke server manapun. Semua data tetap di komputer lokal kamu.

---

## 🔍 Data yang Diakses

geetRPCS mengakses informasi berikut **secara lokal** di komputer kamu:

| Data | Tujuan | Disimpan? | Dikirim ke Server? |
|------|--------|:---------:|:------------------:|
| Nama process aplikasi | Mendeteksi aplikasi yang berjalan | ❌ Tidak | ❌ Tidak |
| Judul window aktif | Menampilkan di Discord presence | ❌ Tidak | ❌ Tidak* |
| Konfigurasi lokal | Menyimpan preferensi pengguna | ✅ Lokal | ❌ Tidak |
| Log aktivitas | Debugging dan troubleshooting | ✅ Lokal | ❌ Tidak |

> *Judul window dikirim ke Discord API untuk ditampilkan sebagai Rich Presence, sesuai dengan persetujuan pengguna.

---

## 📁 File yang Dibuat

geetRPCS membuat file-file berikut di folder instalasi:

```
📁 Folder geetRPCS/
├── 📄 config.json      → Konfigurasi Discord (dibuat oleh pengguna)
├── 📄 apps.json        → Daftar aplikasi (dibuat oleh pengguna)
├── 📄 geetRPCS.log     → Log aktivitas (dibuat otomatis)
└── 🖼️ geetrpcs.ico     → Ikon aplikasi (dibuat oleh pengguna)
```

### Tentang File Log

File `geetRPCS.log` berisi:
- ✅ Waktu aplikasi dimulai/berhenti
- ✅ Nama aplikasi yang terdeteksi
- ✅ Error dan status koneksi Discord
- ❌ **TIDAK** berisi data sensitif
- ❌ **TIDAK** berisi informasi pribadi

Kamu bisa menghapus file log kapan saja tanpa mempengaruhi fungsi aplikasi.

---

## 🌐 Koneksi Jaringan

geetRPCS hanya terhubung ke:

| Layanan | Tujuan | Data yang Dikirim |
|---------|--------|-------------------|
| Discord RPC (lokal) | Menampilkan Rich Presence | Status, detail, gambar yang dikonfigurasi |

### Yang TIDAK Kami Lakukan:

- ❌ **Tidak** menghubungi server eksternal milik kami
- ❌ **Tidak** mengirim analytics atau telemetry
- ❌ **Tidak** mengumpulkan data penggunaan
- ❌ **Tidak** melacak aktivitas browsing
- ❌ **Tidak** mengakses file pribadi
- ❌ **Tidak** membaca konten dokumen

---

## 🔒 Mode Privat

geetRPCS menyediakan fitur **Private Mode** untuk perlindungan privasi tambahan:

### Saat Private Mode AKTIF:
- ✅ Judul window disensor menjadi `********`
- ✅ Nama file/project tidak terlihat di Discord
- ✅ Cocok untuk streaming atau screen sharing

### Cara Mengaktifkan:
1. Double-click ikon tray, atau
2. Klik kanan → pilih "🔒 Private Mode"

---

## 🗂️ Penyimpanan Data

### Data Lokal

Semua data disimpan **secara lokal** di komputer kamu:

| Lokasi | Isi |
|--------|-----|
| Folder instalasi | config.json, apps.json, log |
| Registry Windows* | Path executable (jika auto-startup diaktifkan) |

> *Hanya jika kamu mengaktifkan "Run on Windows startup"

### Registry Entry

Jika auto-startup diaktifkan, geetRPCS membuat entry di:
```
HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
```

Key: `geetRPCS`
Value: Path ke executable

Kamu bisa menghapus entry ini kapan saja melalui menu tray.

---

## 🛡️ Keamanan

### Praktik Keamanan Kami:

- ✅ Tidak ada koneksi ke server eksternal
- ✅ Tidak ada pengumpulan data
- ✅ Kode berjalan sepenuhnya di lokal
- ✅ Tidak memerlukan hak administrator
- ✅ Tidak memodifikasi file sistem

### Rekomendasi Keamanan:

1. Download hanya dari [GitHub resmi](https://github.com/makcrtve/geetRPCS/releases)
2. Verifikasi hash file jika tersedia
3. Jangan jalankan versi yang dimodifikasi pihak ketiga

---

## 👤 Hak Pengguna

Kamu memiliki hak penuh atas data kamu:

| Hak | Cara |
|-----|------|
| **Melihat data** | Buka file config.json dan geetRPCS.log |
| **Mengedit data** | Edit file konfigurasi dengan text editor |
| **Menghapus data** | Hapus folder geetRPCS |
| **Menonaktifkan logging** | Hapus file geetRPCS.log (akan dibuat ulang) |
| **Menghapus dari startup** | Menu tray → uncheck "Run on Windows startup" |

---

## 🔄 Pembaruan Kebijakan

Kebijakan privasi ini dapat diperbarui sewaktu-waktu. Perubahan signifikan akan diumumkan melalui:

- 📋 Release notes di GitHub
- 📄 Update pada file PRIVACY.md

Tanggal "Terakhir diperbarui" di bagian atas dokumen menunjukkan revisi terbaru.

---

## 📞 Kontak

Jika kamu memiliki pertanyaan tentang kebijakan privasi ini:

- 📧 Buat [Issue](https://github.com/makcrtve/geetRPCS/issues) di GitHub

---

## 📜 Persetujuan

Dengan menggunakan geetRPCS, kamu menyetujui:

1. ✅ Data yang dikonfigurasi di config.json akan ditampilkan di Discord
2. ✅ Judul window aplikasi dapat ditampilkan di Discord (kecuali Private Mode aktif)
3. ✅ File log dibuat untuk keperluan debugging

Jika kamu tidak setuju, kamu dapat:
- Tidak menggunakan aplikasi ini
- Mengaktifkan Private Mode untuk menyembunyikan judul window
- Menghapus file log secara berkala

---

<div align="center">

## 🎯 Komitmen Kami

**"Privasi kamu adalah prioritas kami."**

geetRPCS dirancang dengan prinsip **privacy-first**. 
Kami tidak mengumpulkan data karena kami tidak membutuhkannya.

</div>

---

<p align="center">
  <b>geetRPCS</b><br/>
  <sub>© 2025 makcrtve - All Rights Reserved</sub>
</p>
