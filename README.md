# .NET-Raspberry-pi
MENGGUNAKAN .NET CORE SDK DAN RUNTIME DI RASPBERRY  
**Tutorial ini menggunaan Raspi OS**

Tools / Hardware yang digunakan: 
- Raspberry pi 3 Model B V1.2 https://www.raspberrypi.org/products/raspberry-pi-3-model-b/
- Mouse
- Keyboard
- Kabel HDMI 
- Monitor

1. Install OS pada raspbian 
    - Sebelum menginstall OS perlu diperhatikan arsitektur yang akan digunakan ARM64 atau ARM32
    - ada beberapa pilihan os yaitu:
      1. (Rekomendasi) Raspi OS (Raspbian) untuk raspian dengan default menggunakan ARM32                     https://www.raspberrypi.org/downloads/raspberry-pi-os/
      2. Ubuntu OS untuk Raspberry dapat menggunakan versi 19.10.1 atau 20.04 LTS. Untuk Ubuntu OS dapat menggunakan ARM64 dan ARM32 namun OS tidak full packet (tidak ada gui)
      
2. Setelah Install OS pada raspberry jalankan perintah :

    ```
    sudo apt-get update
   
    sudo apt-get upgrade
    ```

   Pada proses ini **Memerlukan koneksi internet**
 
3. Download .NET Core  SDK dan Runtime
    - Versi .NET Core SDK menggunakan NET Core 3.1 SDK (Linux/ARM32) https://download.visualstudio.microsoft.com/download/pr/349f13f0-400e-476c-ba10-fe284b35b932/44a5863469051c5cf103129f1423ddb8/dotnet-sdk-3.1.102-linux-arm.tar.gz
    - Versi .NET Runtime menggunakan ASP.NET Core 3.1 Runtime (Linux/ARM32) https://download.visualstudio.microsoft.com/download/pr/8ccacf09-e5eb-481b-a407-2398b08ac6ac/1cef921566cb9d1ca8c742c9c26a521c/aspnetcore-runtime-3.1.2-linux-arm.tar.gz
  
   Atau menggunakan tools wget:
   ```
   
   wget https://download.visualstudio.microsoft.com/download/pr/349f13f0-400e-476c-ba10-fe284b35b932/44a5863469051c5cf103129f1423ddb8/dotnet-sdk-3.1.102-linux-arm.tar.gz
   
   wget https://download.visualstudio.microsoft.com/download/pr/8ccacf09-e5eb-481b-a407-2398b08ac6ac/1cef921566cb9d1ca8c742c9c26a521c/aspnetcore-runtime-3.1.2-linux-arm.tar.gz
   ```
   
 4. Buat direktori folder untuk menyimpan instalasi SDK dan Runtime contoh "dotnet-arm32 dan unzip file yang didownload sebelumnya ke dalam direktori
    Gunakan Perintah berikut:
    ```
 
    mkdir dotnet-arm32

    tar zxf dotnet-sdk-3.1.102-linux-arm.tar.gz -C $HOME/dotnet-arm32
    
    tar zxf aspnetcore-runtime-3.1.2-linux-arm.tar.gz -C $HOME/dotnet-arm32
    ```
  

  5. Tambahkan environtment variable agar .NET yang di unzip dapat diakses dengan parintah:
  
     ```
     export DOTNET_ROOT=$HOME/dotnet-arm32
     
     export PATH=$PATH:$HOME/dotnet-arm32
     ```
     
     Setelah itu jalankan perintah dotnet --info
     
     ![image](https://user-images.githubusercontent.com/18458955/84618404-53414700-aefc-11ea-98ef-218510f975bb.png)

     
     Biasanya setelah raspberry di Reboot  .NET tidak terdeteksi di bash command (environment .NET tidak auto start)
     ```
     -bash: dotnet: command not found
     ```
     
     Untuk mengatasinya tambahkan environtment dan run file pada .profile file dengan perintah:
     ```
     sudo nano .profile
     ```
     dan tambahkan code pada akhir baris file pada file 
     
     ![image](https://user-images.githubusercontent.com/18458955/84618346-183f1380-aefc-11ea-9f33-3719ed4210c7.png)
     
   6. Membuat contoh project console  *Hello Word* 
      Sebelum membuat sebuah project harus membuat sebuah folder directory contoh: 
      
      
      
      ![image](https://user-images.githubusercontent.com/18458955/84619496-70c3e000-aeff-11ea-80c8-f686aa76d0a3.png)
      
      Setelah itu jalankan perintah 
      ```
      dotnet new console
      ```
      
      
      
      ![image](https://user-images.githubusercontent.com/18458955/84619671-f5aef980-aeff-11ea-8f5b-32d37dda61e3.png)
      
      
      
      Ketika membuat *new console* maka secara default yang dubuat adalah program *Hello World*
      Untuk menjalankan program dapat dilakukan dengan perintah:
      ```
      dotnet run
      ```
      
      **Run perintah di folder project**
      
      
      
      ![image](https://user-images.githubusercontent.com/18458955/84619943-d2d11500-af00-11ea-98e9-0aff609853ae.png)
      
      
      Untuk edit program dapat dilakukan dengan meenggunakan basic code editor dengan perintah:
      ```
      Sudo nano Program.cs
      ```
      
      ![image](https://user-images.githubusercontent.com/18458955/84620155-6571b400-af01-11ea-960b-9095cc2c3049.png)
      
      Ada banyak code editor yang digunakan untuk edit file source code diantara lain:
      - basic code editor (nano)
      - Vim
      - (Rekomendasi) Visual Studio Code
      
      
   7. Install visual studio Code 
      Untuk install visual studio code dapat dilihat pada tutorial berikut:
      ```
      https://medium.com/@melzoghbi/install-visual-studio-code-on-raspbian-eedc566c616d
      
      ```
      
   8. Mengakses raspberry untuk keperluan membuat project,debug dan lain-lain
        - Pastikan SSH pada raspberry sudah di aktifkan, untuk mengakitfkannya dapat menggunakan perintah berikut:
          ```
          Sudo raspi-config
          ```
          
          
          ![image](https://user-images.githubusercontent.com/18458955/84622743-f0ee4380-af07-11ea-8892-7a6572ebf7e2.png)
          
          Masuk ke menu *Interfacing Location* pilih *SSH* dan pilih *enabled*
          
         - Mengakses SSH rapsberry menggunakan Visual studio code (**Sebagai Remote**)
         Pada visual studio install plugin Remote-SSH https://code.visualstudio.com/blogs/2019/07/25/remote-ssh
         
         Setelah di install reload visual studi code dan tekan *Ctrl+Shift+P* maka akan muncul dialog seperti berikut:
         
         ![image](https://user-images.githubusercontent.com/18458955/84623253-1465be00-af09-11ea-973a-e58882b58499.png)
         
         pilih *Connet to Host*
         
         Masukan username dan ip host, karena raspberry pada instalasi biasnya menggunakan username default yaitu *pi* contoh:
         ```
         pi@192.168.x.x
         ```
         
         kemudian masukan password,jika pada waktu instalasi masih setting default maka passwornya adalah *raspberry*
         
         Jika sudah makan akan tampil seperti berikut :
         
         ![image](https://user-images.githubusercontent.com/18458955/84623716-0fedd500-af0a-11ea-989a-175869902b0b.png)
         
   9. Menambahkan nuget package pada project di Visual studio code
      Untuk menambahkan nuget package harus menginstall plugin https://marketplace.visualstudio.com/items?itemName=NuGetTeam.NuGetPackageManager
      Jika sudah berhasil di install reload visual studio code
      
      setelah itu tekan *Ctrl+shift+P* makan akan muncul dialog pilih *Nuget Package Manager: Add Package*
      Masukan nama package yang akan di install
      Pilih versi package
      
      Setelah itu gunakan perintah berikut untuk rebuild project
      ```
      dotnet restore
      dotnet run
      ```
      
      
         
         
# **Contoh Program**

         
          


      
      
      

      
     



      

