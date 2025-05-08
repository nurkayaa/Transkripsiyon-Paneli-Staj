Transkripsiyon Yönetim Paneli

Bu proje, ses dosyalarını dinleyip transkripsiyonlarını düzenlememizi sağlayan bir transkripsiyon yönetim panelidir. Admin ve editör olmak üzere iki kullanıcı rolümüz var. Kullanıcılar, Kullanıcı Adı ve Şifre ile giriş yaptıktan sonra ilk önce otomatik şekilde Editör olarak sistemde bulunurlar, burada örnek ses dosyasını dinleyip ses dosyasının transkripsiyonunu düzenleyip kaydedebiliyorlar. Eğer isterlerse rol seçme kısmından kendilerini Admin seçip kullanıcı işlemlerini görüntüleyebiliyorlar.

Kurulum ve Gereksinimler:
- Node.js (Frontend için)
- Angular CLI (Frontend için)
- ASP.NET Core Web API (Backend için)
- MSSQL Server

Kullanım:

1. Projeyi Çalıştırma

   Frontend (Angular):
	a. Gerekli bağımlılıkları yüklemek için terminalde aşağıdaki komutu çalıştırmalıyız:
        npm install
    
        b. Uygulamayı çalıştırmak için aşağıdaki komutu çalıştırmalıyız:  
        ng serve
    
        - Angular uygulaması artık `http://localhost:4200` adresinde çalışacaktır.

   Backend (ASP.NET Core Web API):
        a. Backend'i çalıştırmadan önce, .NET Core SDK'sının kurulu olduğundan emin olmalıyız.

        b. Backend'i çalıştırmak için terminal veya Visual Studio kullanarak aşağıdaki komutları çalıştırmalıyız:
        dotnet restore
        dotnet run
    
        - Backend API'niz `http://localhost:5004` adresinde aktif olacaktır.
        - http://localhost:5004/swagger adresine gidilirse de Swagger'ı kullanarak API'yi interaktif bir şekilde test etmenizi sağlayabilirsiniz.

2. Kullanıcı Girişi:
       a. Uygulamayı açtıktan sonra, JWT token ile giriş yapabilmek için frontend kısmında login işlemini gerçekleştirin.
       - Hatırlatma! Terminalde backend dosyası altında 'dotnet run' ve frontend dosyası altında 'ng serve' komutlarını token oluşturma ve süresi konusunda sorun yaşamamak için aynı zamanlarda çalıştırmalıyız.
       - Bu sistemde şu an iki tane kullanıcı var. Bu iki kullanıcının kullanıcı adını ve şifresini size iletiyorum, bunları kullanarak giriş yapabilirsiniz.
	1. Kullanıcı Adı: testuser Şifre: testpassword1
	2. Kullanıcı Adı: testuserr Şifre: testpassword1234

       b. JWT Authentication ile giriş yapın. Giriş yaptıktan sonra, token alınacak ve localStorage'a kaydedilecektir.

       c. Backend API'lerine yapılan her istek, token'ı Authorization başlığı altında taşıyacak şekilde yapılmalıdır.
   
3. Rol Seçimi:
      a. Rol Seçin kısmından Admin veya Editor rolünü seçin.
      - Editor rolü için: Ses dosyasını dinleyebilir ve transkripsiyon düzenleyebilirsiniz.
      - Admin rolü için: Kullanıcı işlemlerini görüntüleyebilirsiniz.

4. Transkripsiyon Düzenleme:
     a. Editor rolündeyken, ses dosyasını dinleyin ve metin alanına transkripsiyon yazın.
     b. Transkripsiyonu kaydetmek için `Kaydet` butonuna tıklayın.
     c. Kaydın başarılı olmasının ardından, kullanıcıya bir onay mesajı gösterilecektir.

5. Hata Durumları:
    - Eğer transkripsiyon kaydederken bir hata alırsanız, bir hata mesajı görünecektir.
    - Admin panelindeki loglar alınamazsa, kullanıcıya hata mesajı gösterilecektir.

Not: test-data klasörünün içinde örnek bir ses dosyası ve transcription.json dosyası bulunmaktadır.


Eksiklerim
Kullanıcı İşlemleri (UserActionLog Tablosu):
Admin panelinde Kullanıcı İşlemleri bölümünde, adminlerin kullanıcı aktivitelerini görüntüleyebileceği bir özellik olması istenmişti. Ancak, şu an UserActionLog tablosu ile ilgili bağlantılar düzgün çalıştıramıyorum. Bu nedenle, adminlerin kullanıcı işlemleri geçmişine erişim yok. MSSQL'de bulunan UserActionLog tablosunda tüm transkripsiyon düzenlemeleri görüntülenebiliyor ama bunu admin paneline aktarma konusunda sorun yaşadığım için bu kısım eksik.
