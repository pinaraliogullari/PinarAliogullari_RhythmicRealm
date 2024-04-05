using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhythmicRealm.Entity.Concrete;

namespace RhythmicRealm.Data.Concrete.Configs
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable(nameof(Product));
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Property(p => p.Id).IsRequired();
			builder.HasOne(p => p.SubCategory).WithMany(s => s.Products).HasForeignKey(p => p.SubCategoryId);
			builder.HasOne(p => p.Brand).WithMany(s => s.Products).HasForeignKey(p => p.BrandId);
			builder.HasOne(p => p.Brand).WithMany(b => b.Products).HasForeignKey(p => p.BrandId);

			builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
			builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Url).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Price).IsRequired().HasColumnType("real");
			builder.Property(p => p.Properties).IsRequired().HasMaxLength(1000);
			builder.HasData(
				new Product
				{
					Id = 1,
					Name = "pearl river v-05 dijital piyano",
					SubCategoryId = 1,
					ImageUrl = "piyano1.png",
					Url = "pearl-river-v-05-dijital-piyano",
					Price = 25000,
					IsHome = false,
					BrandId = 2,
					Description = "102011060204 / PEARL RIVER / V-05 WH",
					Properties = "Teknik Özellikler : \r\n\r\nTuş Sistemi :   İtalyan üretimi  Fatar Grand-Response™ 88 Tuşlu Tuş yapısı -  Çekiç Aksiyon Sistemi - Dinamik Eğrili Sensör Sistemi - 4 Farklı Hassasiyet ayarı \r\n\r\nPolifoni : 512\r\n\r\nSes Sayısı :  26 farklı Ses -  Avrupa Konser tipi Kuyruklu Piyano  örneklemesi ile yapılmış ana piyano sesi  - Ritm Perküsyon Ses Dizilimli  Ses Örneklemeleri \r\n\r\nKullanım Özelikleri :  Çift Ses birleştirme,   Klayyede bölerek iki ses kullanımı ( Split ) \r\n\r\nMetronom : Mevcut \r\n\r\nTranspose : Mevcut \r\n\r\nBluetooth : Mevcut\r\n\r\nEfekt Özellikleri : Reverb ve Chorus Efektleri \r\n\r\nKayıt Özellikleri :  22000 Nota uzunluğuna kadar Kayıt imkanı \r\n\r\nKayıtlı Eserler :  75 farklı   Demo şarkıları \r\n\r\nBağlantılar : USB, Kulaklık Çıkışı ( 2 adet ) , Line in ve Line Out Bağlantıları  \r\n\r\nBluetooth Audio Bağlantısı : Mevcut\r\n\r\nSes Çıkışı :  25 Watt x 2 \r\n\r\nGenişlik : 137cm\r\n\r\nYükseklik : 81,5cm \r\n\r\nDerinlik : 42cm \r\n\r\nAğırlık : 46,5 Kg \r\n\r\nElektrik Bağlantısı :  DC 12V Adaptör ile Çalışır "

				},
				new Product
				{
					Id = 2,
					Name = "kurzweil dijital kuyruklu piyano",
					SubCategoryId = 1,
					ImageUrl = "piyano2.png",
					Url = "kurzveil-dijital-kuyruklu-piyano",
					Price = 80000,
					IsHome = true,
					BrandId = 2,
					Description = "102021910201 / KURZWEIL / KAG100WHP\r\n",
					Properties = "Klavye: 88 standard-ölçülü hammer tuşlar (A0~C8) \r\nTuş hassasiyeti: 3 farklı descede seçilebilir tuş hassasiyeti\r\nEkran: 2*16 alphanumeric LCD Ekran\r\nPolifoni: 64 Ses\r\nHazır Programlar: 200\r\nKullanıcı Hazır Sesleri: 20\r\nGenel MIDI: Yok\r\nDemos Şarkılar: 71\r\nÖğrenilen Şarkılar 55\r\nSplits/Layers: Quick Split/Layer, easy access with adjustable relative volume\r\nTranspoze: Full transposition to any key, +/- one octave\r\nAkort: +/- 1 semitone\r\nEfektler: 8 reverb types (plus level); 8 chorus types (plus level); Treble/Bass EQ\r\nAuto-Accompaniment: 100 styles plus 1 user\r\nMetronom: Var\r\nRecorder/Sequencer: 2-Track\r\nSes Sistemş: 4-Hoparlör, 20W+15W, stereo\r\nSes Çıkışları: Stereo left/right RCA line outs (for connecting to external amplification)\r\nSes Girişleri: Stereo left/right RCA line ins (for connecting external sound sources)\r\nLine Çıkışı: Var\r\nKulaklık Girişi: (2) 1/4″ stereo kulaklık çıkışı\r\nUSB: (1) port;  MIDI ve audio over USBBluetooth:    Yes (incl. blue tooth receiver)\r\nPedals:    (3) Dahili switch-type: sustain, sostenuto, soft\r\nGüç: Internal Power Supply"

				},
				new Product
				{
					Id = 3,
					Name = "AP270BK celviano dijital piyano",
					SubCategoryId = 1,
					ImageUrl = "piyano3.png",
					Url = "casio-ap20bk-celviano-dijital-piyano",
					Price = 29999,
					IsHome = false,
					BrandId = 1,
					Description = "102010290110 / CASIO / AP270BK",
					Properties = "TEKNİK ÖZELLİKLER\r\nKlavye: 88 tuş, Üç Sensörlü Ölçekli Çekiç Aksiyonlu Klavye II, benzetilmiş abanoz ve fildişi kaplama tuşlar\r\nDokunuş Tepkisi: 3 hassasiyet seviyesi, Kapalı\r\nSes Kaynağı: AiR ses kaynağı, damper rezonansı, çekiç tepkisi, damper parazit\r\nMaksimum Polifoni: 192\r\nTonlar: Kuyruklu Piyano 1, Kuyruklu Piyano 2 tonları dahil toplam 22 ton\r\nKatman / Bölme: Katman (Bas tonları hariç), Bölme (Yalnızca alt aralıktaki bas tonları)\r\nDijital Efektler: Reverb (4 tür), Chorus (4 tür), Brilliance (-3 - 0 - 3), DSP (bazı tonlarda dahilidir)\r\nDahili Şarkılar: 10 (Konser Çalma), 60 (Müzik Kitaplığı)\r\nŞarkı Genişletme: 10 şarkı (maks.) Şarkı başına en fazla yaklaşık 90 KB\r\nDers İşlevi: Bölüm AÇIK / KAPALI (Ders bölümü: Sağ el/Sol el)\r\nMetronom: Vuruş: 0 - 9 (Tempo aralığı: dörtlük = 20 - 255)\r\nMIDI Kaydedici: 2 kanal x 1 şarkı, maksimum yaklaşık 5.000 nota, gerçek zamanlı kayıt/playback\r\nNotaya Aktarma: 2 oktav (-12 yarı ton ~ 0 ~ +12 yarı ton)\r\nAkortlama Kontrolü: A4 = 415,5 Hz ~ 440,0 Hz ~ 465,9 Hz\r\nPedallar: 3 pedal (damper, yumuşak, sostenuto)\r\n*damper = açık/kapalı\r\nMIDI: Bu üründe MIDI terminalleri bulunmaz. Ürün ve bilgisayar arasındaki MIDI iletişimi, USB bağlantı noktası aracılığıyla yapılır.\r\nHoparlörler: 12 cm x 2\r\nAmp Çıkışı: 8W + 8W\r\n\r\nGiriş/Çıkış Uçları: KULAKLIK/ÇIKIŞ x 2 (Stereo standart)\r\n\r\nUSB: Tip B\r\n\r\nHarici güç (12V DC)\r\n\r\n* Bilgisayara bağlanmak amacıyla USB terminalini kullanmak için USB kablosu (A-B tipi) gereklidir.\r\nGüç Gereksinimleri: AC adaptör: AD-A12150LW\r\nBoyutlar (G x D x Y): 1.417 x 432 x 821mm (nota sehpası hariç)\r\nAğırlık: 36,6kg\r\nBirlikte Verilen Aksesuarlar: Piyano Taburesi, AC Adaptör (AD-A12150LW), Nota Sehpası "

				},
				 new Product
				 {
					 Id = 4,
					 Name = "piaggero tuşlu eğitim klavyesi",
					 ImageUrl = "klavye1.png",
					 SubCategoryId = 2,
					 Url = "yamaha-piaggero-tuslu-egitim-klavyesi",
					 Price = 14500,
					 IsHome = true,
					 BrandId = 2,
					 Description = "103011500112 / YAMAHA / NP15B",
					 Properties = "Teknik Özellikler\r\n\r\nTipi: Eğitim Klavyesi\r\nSes Teknoojisi: AWN Stereo Sampling\r\nTuş Sayısı: 61\r\nTuş Tipi: Yarı-Ağırlıklı\r\nTouch Sensitivity: Hard, Medium, Soft, Fixed\r\nPolifoni: 64 Nota\r\nHazır Sesler: 15 Ses\r\nEfektler: 6 x Reverb\r\nSes Kayıt: 1 parça (7,000 nota'ya kadar.)\r\nSes Çıkışları: 1 x 1/4\" (phones/output)\r\nUSB: 1 x Type B\r\nMIDI I/O: USB\r\nPedal Girişkerş: 1 x 1/4\" (sustain)\r\nDahili Hoparlör: 2 x (4.75\" x 3.14\")\r\nAmpfi: 2 x 2.5W\r\nGüç Desteği: 6 x AA, 12V DC (1A) power supply "

				 },
				 new Product
				 {
					 Id = 5,
					 Name = "MZ-61 tuşlu klavye",
					 ImageUrl = "klavye2.png",
					 SubCategoryId = 2,
					 Url = "casio-mz61-tuslu-klavye",
					 Price = 32800,
					 IsHome = false,
					 BrandId = 2,
					 Description = "103010290039/CASIO/MZX500",
					 Properties = "Teknik Özellikler\r\n\r\nTipi: Eğitim Klavyesi\r\nSes Teknoojisi: AWN Stereo Sampling\r\nTuş Sayısı: 61\r\nTuş Tipi: Yarı-Ağırlıklı\r\nTouch Sensitivity: Hard, Medium, Soft, Fixed\r\nPolifoni: 64 Nota\r\nHazır Sesler: 15 Ses\r\nEfektler: 6 x Reverb\r\nSes Kayıt: 1 parça (7,000 nota'ya kadar.)\r\nSes Çıkışları: 1 x 1/4\" (phones/output)\r\nUSB: 1 x Type B\r\nMIDI I/O: USB\r\nPedal Girişkerş: 1 x 1/4\" (sustain)\r\nDahili Hoparlör: 2 x (4.75\" x 3.14\")\r\nAmpfi: 2 x 2.5W\r\nGüç Desteği: 6 x AA, 12V DC (1A) power supply "

				 },
				 new Product
				 {
					 Id = 6,
					 Name = "tuşlu klavye",
					 ImageUrl = "klavye3.png",
					 SubCategoryId = 2,
					 Url = "casio-61-tuslu-klavye",
					 Price = 25000,
					 IsHome = false,
					 BrandId = 1,
					 Description = "102011060204 / PEARL RIVER / V-05 WH",
					 Properties = "CASIO'nun gelişmiş dijital teknolojileri, rock ve caz hayranları arasında popüler olan eski mekanik ton dişli org seslerini aslına uygun olarak üretir. Orgun yalnızca döner hoparlörlerine özel sarsıntılar değil, aynı zamanda gürültü kaçakları da doğru şekilde üretilir. Geliştiricilerin geleneksel ton dişli orgdaki derin, ağır rezonansı elde etme konusundaki kararlılığı sayesinde hoş seslerden oluşan zengin bir ses grubu ortaya çıkmıştır.\r\n\r\nHex Layer ve Synth\r\n\r\nDahili bir Hex Layer (yalnızca MZ-X500) altı adede kadar farklı tonu birleştirerek müziğin güçlü ifade şekline katkıda bulunan polifonik ses üretir. Ayrıca dahili Bass Synth işlevi de bulunur. Bu işlev, monofonik ses ve geleneksel analog synthesizer'ları anımsatan portamento efekti üretir."

				 },
				 new Product
				 {
					 Id = 7,
					 Name = "hohner A16812 bravo 120 akordiyon ",
					 ImageUrl = "akordiyon1.png",
					 SubCategoryId = 3,
					 Url = "hohner-a16812-bravo-120-akordiyon",
					 Price = 32000,
					 IsHome = true,
					 BrandId = 1,
					 Description = "103030640208 / HOHNER / A16812",
					 Properties = "Teknik Özellikler\r\n\r\nTuş Sayısı: 41\r\nNota Sayısı: 41, F - A\r\nSınıfı: Kromatik\r\nKamış Plaka Seti: 3\r\nRegister Sayısı: 7\r\nTon Sayısı: 5\r\nStandart Baslar: 120\r\nStandart Bas (Kamış Plaka Seti): 4\r\nStandart Bas Register: 3\r\nÖlçüleri: 44 x 18,5 cm\r\nKamış Plaka Seti Kalitesi: Standart\r\nAğırlığı: 9,2 kg\r\nİlave İçerik: Askılı Taşıma Çantası.\""

				 },

				 new Product
				 {
					 Id = 8,
					 Name = "prs se standart elektro gitar",
					 ImageUrl = "elektrogitar1.png",
					 SubCategoryId = 4,
					 Url = "prs-se-standart-elektro-gitar",
					 Price = 35000,
					 IsHome = true,
					 BrandId = 1,
					 Description = "104081122078 / PRS - PAUL REED SMITH / ST844TB",
					 Properties = "Teknik Özellikler\r\n\r\nÖn Gövde: Maun\r\nGövde: Maun\r\nGövde Carve: Shallow Violin Carve\r\nPerde Sayısı: 24\r\nUzunluk: 25”\r\nSap (Neck): Akçaağaç\r\nSap (Neck) Şekli: Wide Thin\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: “Old School” Birds\r\nKöprü (Bridge): PRS Patented Tremolo, Molded\r\nBurgular: PRS-Designed Tuners\r\nAksamlar: Nikel\r\nTruss Rod Cover: “Custom”\r\nKöprü (Bridge) Manyetiği: TCI “S” Treble\r\nSap (Neck) Manyetiği: TCI “S” Bass\r\nKontroller: Volume and Tone Control with 3-Way Toggle Pickup Switch and Two Mini-Toggle Coil-Tap Switches\r\nTeller: PRS Classic, 9-42\r\nTaşıma Çantası: PRS Gig Bag "

				 },
				 new Product
				 {
					 Id = 9,
					 Name = "prs se custom elektro gitar",
					 ImageUrl = "elektrogitar2.png",
					 SubCategoryId = 4,
					 Url = "prs-se-custom-elektro-gitar",
					 Price = 43000,
					 IsHome = false,
					 BrandId = 1,
					 Description = "104081121601 / PRS - PAUL REED SMITH / SEC844TU",
					 Properties = "Teknik Özellikler\r\n\r\nÖn Gövde: Akçaağaç w/ Flame Akçaağaç Veneer\r\nGövde: Maun\r\nGövde Carve: Shallow Violin Carve\r\nPerde Sayısı: 24\r\nUzunluk: 25”\r\nSap (Neck): Akçaağaç\r\nSap (Neck) Şekli: Wide Thin\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: “Old School” Birds\r\nKöprü (Bridge): PRS Patented Tremolo, Molded\r\nBurgular: PRS-Designed Tuners\r\nAksamlar: Nikel\r\nTruss Rod Cover: “Custom”\r\nKöprü (Bridge) Manyetiği: TCI “S” Treble\r\nSap (Neck) Manyetiği: TCI “S” Bass\r\nKontroller: Volume and Tone Control with 3-Way Toggle Pickup Switch and Two Mini-Toggle Coil-Tap Switches\r\nTeller: PRS Classic, 9-42\r\nTaşıma Çantası: PRS Gig Bag "

				 },
				 new Product
				 {
					 Id = 10,
					 Name = "seagull s6 collection akustik gitar",
					 ImageUrl = "akustikgitar1.png",
					 SubCategoryId = 5,
					 Url = "seagull-s6-collection-akustik-gitar",
					 Price = 30600,
					 IsHome = true,
					 BrandId = 1,
					 Description = "104041230601/SEAGULL/052431",
					 Properties = "Teknik Özellikler\r\n\r\nTel Tipi: Çelik\r\nTel Sayısı: 6\r\nÇalım: Sağ El\r\nGövde Şekli: Dreadnought\r\nÖn Gövde: Sedir\r\nFinish: Yarı Parlak\r\nRenk: Natural\r\nBody Bracing: Fan bracing\r\nSap (Neck): Silver Leaf Akçaağaç\r\nSap (Neck) Şekli: D\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: Circular Plastic\r\nPerde Sayısı: 22, Nickel Silver\r\nUzunluk: 24.84\"\r\nEşik Genişiği: 1.8\"\r\nEşik/Saddle: Graph Tech\r\nKöprü (Bridge): Gülağacı\r\nBurgular: Sealed Chrome, 14:1 ratio\r\nTeller: Godin A6 LT, .012-.053 "

				 },
				 new Product
				 {
					 Id = 11,
					 Name = "seagull ml akustik gitar",
					 ImageUrl = "akustikgitar2.png",
					 SubCategoryId = 5,
					 Url = "seagull-m6-akustik-gitar",
					 Price = 42600,
					 IsHome = false,
					 BrandId = 1,
					 Description = "104051231201/SEAGULL/052424",
					 Properties = "Tel Tipi: Çelik\r\nTel Sayısı: 6\r\nÇalım: Sağ El\r\nGövde Şekli: Concert\r\nÖn Gövde: Sedir\r\nFinish: Parlak\r\nRenk: Ruby Red\r\nBody Bracing: X-bracing\r\nSap (Neck): Silver Leaf Akçaağaç\r\nSap (Neck) Şekli: D\r\nRadius: 16\"\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: Noktalar\r\nPerde Sayısı: 21\r\nUzunluk: 25.5\"\r\nEşik Genişiği: 1.8\"\r\nEşik/Saddle: Tusq/Tusq\r\nKöprü (Bridge): Gülağacı\r\nBurgular: Open-gear\r\nPreamp: Fishman Sonitone\r\nTeller: Godin A6 LT, .012-.053\r\nTaşıma Çantasu: Gig Bag "

				 },
				 new Product
				 {
					 Id = 12,
					 Name = "gibson standart akustik gitar",
					 ImageUrl = "akustikgitar3.png",
					 SubCategoryId = 5,
					 Url = "gibson-standart-akustik-gitar",
					 Price = 33000,
					 IsHome = false,
					 BrandId = 1,
					 Description = "104050570703 / GIBSON / MCRS45CH",
					 Properties = "Teknik Özellikler\r\n\r\nTel Tipi: Çelik\r\nTel Sayısı: 6\r\nÇalım: Sağ El\r\nGövde Şekli: J-45 Dreadnought\r\nArka & Yanlar: Maun\r\nÖn Gövde: Sitka Ladin\r\nFinish: Gloss Nitrocellulose Lacquer\r\nRenk: Cherry\r\nBinding: Multi-ply\r\nSap (Neck): Maun\r\nSap (Neck) Şekli: Slim Taper\r\nRadius: 12\"\r\nKlavye: Hint Gülağacı\r\nKlavye İşaretleri: Mother-of-Pearl Dots\r\nPerdeler: 20\r\nUzunluk: 24.75\"\r\nEşik Genişliği: 1.725\"\r\nEşik/Saddle: Tusq/Tusq\r\nKöprü (Bridge): Gülağacı Reverse Belly\r\nBurgular: Grover Rotomatics\r\nPreamo: LR Baggs VTC\r\nTeller: Gibson, .012-.053\r\nCase: Hardshell Case"

				 },
				 new Product
				 {
					 Id = 13,
					 Name = "epiphone mm-30S mandolin",
					 ImageUrl = "mandolin1.png",
					 SubCategoryId = 6,
					 Url = "epiphone-mm-30s-mandolin",
					 Price = 8500,
					 IsHome = true,
					 BrandId = 1,
					 Description = "104130571101/EPIPHONE/EF30ASGH1",
					 Properties = "Stil: F-Style\r\nGövde Derinlik: 50 mm\r\nÖn Gövde: Ladin\r\nArka ve Yanlar: Akçaağaç\r\nSap (Neck): Akçaağaç\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: inlays\r\nEşik Genişliği: 28 mm\r\nUzunluk: 350 mm\r\nPerdeler: 24\r\nKöprü (Bridge): Rosewood\r\nBurgular: Chrome-plated\r\nRenk: Whiskey Burst Satin"

				 },
				 new Product
				 {
					 Id = 14,
					 Name = "8 telli mandolin",
					 ImageUrl = "mandolin2.png",
					 SubCategoryId = 6,
					 Url = "8-telli-mandolin",
					 Price = 11800,
					 IsHome = true,
					 BrandId = 1,
					 Description = "10413216580 /ORTEGA/RMF30-WB",
					 Properties = "Stil: F-Style\r\nGövde Derinlik: 50 mm\r\nÖn Gövde: Ladin\r\nArka ve Yanlar: Akçaağaç\r\nSap (Neck): Akçaağaç\r\nKlavye: Gülağacı\r\nKlavye İşaretleri: inlays\r\nEşik Genişliği: 28 mm\r\nUzunluk: 350 mm\r\nPerdeler: 24\r\nKöprü (Bridge): Rosewood\r\nBurgular: Chrome-plated\r\nRenk: Whiskey Burst Satin"

				 },
		   new Product
		   {
			   Id = 15,
			   Name = "art series concert ukulele",
			   ImageUrl = "ukulele1.png",
			   SubCategoryId = 7,
			   Url = "art-series-concert-ukulele",
			   Price = 2800,
			   IsHome = true,
			   BrandId = 1,
			   Description = "104122165710/ORTEGA /RUAR-EY",
			   Properties = "Teknik Özellikler\r\n\r\nSize: Concert \r\nScale: 380 mm\r\nEşik Genişliği: 36 mm\r\nPerdeler: 18\r\nTel Sayısı: 4\r\nÖn Gövde: Ladin\r\nRenk: Egypt Custom\r\nFinish: Satin \r\nSap (Neck): Nato\r\nKöprü (Bridge): Akçaağaç\r\nKlavye: Akçaağaç\r\nBurgular: Die-cast tuning machines, gold w/ gold buttons"

		   },
		   new Product
		   {
			   Id = 16,
			   Name = "all solid elektro tenor ukulele",
			   ImageUrl = "ukulele2.png",
			   SubCategoryId = 7,
			   Url = "all-solid-elektro-tenor-ukulele",
			   Price = 5100,
			   IsHome = false,
			   BrandId = 1,
			   Description = "104120939928/MAHALO/MM3E",
			   Properties = "Teknik Özellikler\r\n\r\nMarka: Mahalo\r\nÖn Gövde: SOLID Red Cedar\r\nArka ve Yanlar: Solid Maun\r\nBracing: Toneflow Bracing\r\nSap (Neck): Tek Parça Maun\r\nKlavye: Amara Abanoz\r\nKöprü (Bridge): Amara Abanoz\r\nBurgular: Waverly Style, Gold Plated with Ivoroid Button"

		   },
		   new Product
		   {
			   Id = 17,
			   Name = "mavis laminated keman",
			   ImageUrl = "keman1.png",
			   SubCategoryId = 8,
			   Url = "mavis-laminated-keman",
			   Price = 1900,
			   IsHome = true,
			   BrandId = 1,
			   Description = "107010959912 / MAVIS / MV012L 1/4",
			   Properties = "Teknik Özellikler\r\n\r\nKutu, Arşe ve Reçine dahil..\r\nKatı preslenmiş ladin ağacı salyangoz\r\nKatı preslenmiş akçaağaç gövde\r\nSiyah boyalı akçaağaçtan klavye ve pigler"

		   },
		   new Product
		   {
			   Id = 18,
			   Name = "donner rising carbon fiber keman seti",
			   ImageUrl = "keman2.png",
			   SubCategoryId = 8,
			   Url = "donner-rising-carbon-fiber-keman-seti",
			   Price = 16000,
			   IsHome = false,
			   BrandId = 1,
			   Description = "107012560101 / DONNER / EC1531",
			   Properties = "Teknik Özellikler\r\n\r\nKutu, Arşe ve Reçine dahil..\r\nKatı preslenmiş ladin ağacı salyangoz\r\nKatı preslenmiş akçaağaç gövde\r\nSiyah boyalı akçaağaçtan klavye ve pigler"

		   },
		   new Product
		   {
			   Id = 19,
			   Name = "silent keman",
			   ImageUrl = "keman3.png",
			   SubCategoryId = 8,
			   Url = "yamaha-silent-keman",
			   Price = 28000,
			   IsHome = false,
			   BrandId = 2,
			   Description = "10702150010/YAMAHA/YSV104BLA02",
			   Properties = "Teknik Özellikler\r\n\r\nÜrün Kodu: YSV104BRO \r\nTür: Silent Keman\r\nÖlçü: 4/4\r\nGövde: Ladin\r\nSap (Neck): Akçaağaç\r\nKlavye: Kompozit\r\nBurgular: Abanoz\r\nTeller: D'Addario Zyex "

		   },
		   new Product
		   {
			   Id = 20,
			   Name = "viyola seti",
			   ImageUrl = "viyola1.png",
			   SubCategoryId = 9,
			   Url = "yamaha-viyola-seti",
			   Price = 34000,
			   IsHome = true,
			   BrandId = 2,
			   Description = "107031509907/YAMAHA/KVA5S16",
			   Properties = "Teknik Özellikler\r\n\r\nTip: Stradivarius\r\nBoyut: 16\"\r\nÜst Kapak: Ladin\r\nArka Kapak: Akçaağaç\r\nYan Kapaklar: Akçaağaç\r\nSap: Akçaağaç\r\nKlavye: Abanoz\r\nCila: Poliüretan\r\nBurgular: Abanoz\r\nKuyruk: Wittner \"Ultra\" (4 Adet Fiks)\r\nFiksler: Wittner \"Ultra\" (4 Adet Fiks)\r\nEşik: Yamaha Orijinal\r\nÇenelik: Abanoz\r\nTeller: Prelude\r\nKutu: Var\r\nYay: Brazilian Ağacı\r\nReçine: Piranito "

		   },
		   new Product
		   {
			   Id = 21,
			   Name = "va5s viyola",
			   ImageUrl = "viyola2.png",
			   SubCategoryId = 9,
			   Url = "yamaha-va5s-seti",
			   Price = 35000,
			   IsHome = false,
			   BrandId = 2,
			   Description = "107031509904/YAMAHA/VA5S16",
			   Properties = "Teknik Özellikler\r\n\r\nTip: Stradivarius\r\nBoyut: 16\"\r\nÜst Kapak: Ladin\r\nArka Kapak: Akçaağaç\r\nYan Kapaklar: Akçaağaç\r\nSap: Akçaağaç\r\nKlavye: Abanoz\r\nCila: Poliüretan\r\nBurgular: Abanoz\r\nKuyruk: Wittner \"Ultra\" (4 Adet Fiks)\r\nFiksler: Wittner \"Ultra\" (4 Adet Fiks)\r\nEşik: Yamaha Orijinal\r\nÇenelik: Abanoz\r\nTeller: Prelude\r\nKutu: Var\r\nYay: Brazilian Ağacı\r\nReçine: Piranito "

		   },
		   new Product
		   {
			   Id = 22,
			   Name = "mc6012 çello",
			   ImageUrl = "cello1.png",
			   SubCategoryId = 10,
			   Url = "rösler-mc6012-cello",
			   Price = 23500,
			   IsHome = true,
			   BrandId = 3,
			   Description = "107041209902/RÖSLER/MC6012 1/2",
			   Properties = "Teknik Özellikler\r\n\r\nÖn Kapak: Ladin\r\nYan - Arka: Akçaağaç\r\nKlavye: Ebonit\r\nKuyruk: Dahili 4 fixli kuyruk\r\nBurgu: Ebonit\r\nVernik: Parlak Cila\r\nKutu İçeriği: Taşıma Çantası, Yay"

		   },
		   new Product
		   {
			   Id = 23,
			   Name = "dijital saksafon",
			   ImageUrl = "saksafon1.png",
			   SubCategoryId = 11,
			   Url = "yamaha-dijital-saksafon",
			   Price = 38000,
			   IsHome = true,
			   BrandId = 3,
			   Description = "108351500001/YAMAHA/YDS150",
			   Properties = "Teknik Özellikler\r\n\r\nAkustik Saksafon ile aynı tuş düzenine sahiptir.\r\nAWM (Advanced Wave Memory) sampling\r\n73 Ses - 56 Saksafon sesi\r\n5 Efekt\r\nVolume Kontrolü ile 15 farklı seviye\r\nAkort Modu: Eb, Bb, C\r\nAkort: 427 - 453 Hz (0.5 Hz'e kadar ayarlanabilir.)\r\nAuto power off\r\nBluetooth\r\nIos veya Android uygulaması: Sesleri değiştir, fingering, enstrüman ayarlamaları\r\nStereo Kulaklık Çıkışı: 3.5 mm Mini jack\r\nMicro USB tip B\r\nBatarya (4x AAA) veya harici USB güç desteği ile çalışır.(Kutu içeriğine dahil değildir.)\r\nGüç Tüketimi: 4.5 W (USB kullanımı esnasında.)"

		   },
			new Product
			{
				Id = 24,
				Name = "bohemia tenor saksafon",
				ImageUrl = "saksafon2.png",
				SubCategoryId = 11,
				Url = "bohemia-tenor-saksafon",
				Price = 25800,
				IsHome = false,
				BrandId = 3,
				Description = "108351500001/BOHEMIA/YDS150",
				Properties = "Teknik Özellikler\r\n\r\nBohemia XTN2001 Tenor Saksafon\r\n\r\nÖğrenci Seviyesi\r\nAltın Lake Kaplama\r\n'Bb' Tenor Saksafon\r\nKumaş Sert Çanta\r\nAskı\r\nAğızlık Set\r\n2 Yıl Garanti"

			},
			 new Product
			 {
				 Id = 25,
				 Name = "bemol klarnet",
				 ImageUrl = "klarnet1.png",
				 SubCategoryId = 12,
				 Url = "jinbao-bemol-klarnet",
				 Price = 6800,
				 IsHome = false,
				 BrandId = 3,
				 Description = "108070730004/JINBAO/JBCL-570",
				 Properties = "Teknik Özellikler\r\n\r\nJinbao XTN2001 Tenor Saksafon\r\n\r\nÖğrenci Seviyesi\r\nAltın Lake Kaplama\r\n'Bb' Tenor Saksafon\r\nKumaş Sert Çanta\r\nAskı\r\nAğızlık Set\r\n2 Yıl Garanti"

			 },
			  new Product
			  {
				  Id = 26,
				  Name = " bohemia plus sol klarnet",
				  ImageUrl = "klarnet2.png",
				  SubCategoryId = 12,
				  Url = "bohemia-plus-sol-klarnet",
				  Price = 10100,
				  IsHome = true,
				  BrandId = 3,
				  Description = "108330220010/BOHEMIA/XCL340W",
				  Properties = "Teknik Özellikler\r\n\r\nBakalit\r\n4 Yüzüklü.\r\nNikel kaplama.\r\nErgonomik tuş tasarımı sayesinde rahat çalım imkanı sunmaktadır.\r\n2 adet baril kutu içeriğinde bulunmaktadır. (68 mm, 70 mm)"
			  },
				 new Product
				 {
					 Id = 27,
					 Name = "si bemol klarnet",
					 ImageUrl = "klarnet3.png",
					 SubCategoryId = 12,
					 Url = "antigua-si-bemol-klarnet",
					 Price = 37000,
					 IsHome = false,
					 BrandId = 3,
					 Description = "108070100101/ANTIGUA/WCL3230S-WH",
					 Properties = "Teknik Özellikler\r\n\r\nBakalit\r\n4 Yüzüklü.\r\nNikel kaplama.\r\nErgonomik tuş tasarımı sayesinde rahat çalım imkanı sunmaktadır.\r\n2 adet baril kutu içeriğinde bulunmaktadır. (68 mm, 70 mm)"
				 },
				 new Product
				 {
					 Id = 28,
					 Name = "blues bender si bemol major mızıka",
					 ImageUrl = "mızıka1.png",
					 SubCategoryId = 13,
					 Url = "blues-bender-si-bemol-major-mizika",
					 Price = 732,
					 IsHome = false,
					 BrandId = 3,
					 Description = "108160645008/HOHNER/M58611X",
					 Properties = "Metal bb sibemol major mızıka"
				 },
				 new Product
				 {
					 Id = 29,
					 Name = "bohemia yan flüt",
					 ImageUrl = "yanflut1.png",
					 SubCategoryId = 14,
					 Url = "bohemia-yan-flut",
					 Price = 5955,
					 IsHome = true,
					 BrandId = 3,
					 Description = "108010220001/BOHEMIA/XFL003",
					 Properties = "Bohemia BFL003 Yan Flüt\r\nÖğrenci Seviyesi\r\nGümüş Kaplama\r\nKapalı Tuşe Sistemli\r\n'C' Flüt\r\nKumaş Sert Çanta\r\nTemizlik Bezi Set\r\n2 Yıl Garanti"
				 },
				 new Product
				 {
					 Id = 30,
					 Name = "yan flüt",
					 ImageUrl = "yanflut2.png",
					 SubCategoryId = 14,
					 Url = "antigua-yan-flut",
					 Price = 16263,
					 IsHome = true,
					 BrandId = 3,
					 Description = "108010100001/ANTIGUA/FL2210-A",
					 Properties = "Antigua FL2210A Yan Flüt\r\n\r\nOrta Seviye\r\nGümüş Kaplama\r\nKapalı Tuşe Sistemli\r\n'C' Flüt\r\nSert Kabuk Çanta\r\nTemizlik Bezleri Set\r\n2 Yıl Garanti"
				 },
				 new Product
				 {
					 Id = 31,
					 Name = "conductor gümüş yan flüt",
					 ImageUrl = "yanflut3.png",
					 SubCategoryId = 14,
					 Url = "conductor-gumus-yan-flut",
					 Price = 6692,
					 IsHome = false,
					 BrandId = 3,
					 Description = "108010320901/CONDUCTOR/M1115S",
					 Properties = "CONDUCTOR M1115\r\n\r\nÖğrenci Seviyesi\r\n\r\nGümüş Kaplama\r\n\r\nKapalı Tuşe Sistemli,\r\n\r\nC' Flüt\r\n\r\nKumaş Sert Çanta\r\n\r\nTemizlik Bezi Set\r\n\r\n2 Yıl Garanti"
				 },
				 new Product
				 {
					 Id = 32,
					 Name = "jinbao trampet",
					 ImageUrl = "akustikdavul1.png",
					 SubCategoryId = 15,
					 Url = "jinbao-trampet",
					 Price = 2455,
					 IsHome = true,
					 BrandId = 4,
					 Description = "109230730002/JINBAO/JBS-1059",
					 Properties = "2 yıl garantili ,başlangıç seviye trampet"
				 },
				 new Product
				 {
					 Id = 33,
					 Name = "jinbao timbal",
					 ImageUrl = "perkusyon1.png",
					 SubCategoryId = 16,
					 Url = "jinbao-timbal",
					 Price = 4591,
					 IsHome = false,
					 BrandId = 4,
					 Description = "109190730001/JINBAO/JBTB1413",
					 Properties = "2 yıl garantili ,başlangıç seviye trampet"
				 },
				 new Product
				 {
					 Id = 34,
					 Name = "jinbao alto glockenspiel",
					 ImageUrl = "perkusyon2.png",
					 SubCategoryId = 16,
					 Url = "jinbao-Alto-glockenspiel",
					 Price = 5615,
					 IsHome = false,
					 BrandId = 4,
					 Description = "109250730002/JINBAO/JB500AG",
					 Properties = "Yüksek Kaliteli Malzeme: Dayanıklı ve uzun ömürlü çalma deneyimi için sağlam yapıda malzemeler kullanılmıştır.\r\nSes Aralığı: Belirli bir not aralığını kapsayan ve doğru tonları sağlayan çeşitli notların bulunduğu geniş bir ses aralığına sahiptir.\r\nTaşınabilirlik: Hafif ve kompakt tasarımı sayesinde kolayca taşınabilirdir."
				 },
				 new Product
				 {
					 Id = 35,
					 Name = "meinl hihat zil",
					 ImageUrl = "zil1.png",
					 SubCategoryId = 17,
					 Url = "meinl-Hihat-zil",
					 Price = 12212,
					 IsHome = true,
					 BrandId = 4,
					 Description = "109052178516/MEINL/PAC14MTH",
					 Properties = "Meinl PAC14MTH 14\" Pure Alloy Custom MT Meinl Hihat Zil (Çift)\r\n\r\nMeinl PAC14MTH 14\", Net ve güçlü bir ses sunar. dayanıklı ve kaliteli hi-hat zil arayan müzisyenler için idealdir.\r\n\r\nGenel özellikler\r\n\r\nGeniş ses aralığı, net ve hassas.\r\nAlmanya'da üretilmiştir.\r\nMüzik Stili:\r\n\r\nRock, Pop, Fusion, R&B, Reggae, Stüdyo"
				 },
				new Product
				{
					Id = 36,
					Name = "jazz medium thin crash zil",
					ImageUrl = "zil2.png",
					SubCategoryId = 17,
					Url = "jazz-medium-thin-crash-zil",
					Price = 11584,
					IsHome = true,
					BrandId = 4,
					Description = "109052178504 / MEINL / B17JMTC",
					Properties = "Meinl B17JMTC Byzance 17\" Jazz Medium Thin Crash Zil\r\n\r\nMeinl B17JMTC, Sıcak ve net bir sese sahiptir. dayanıklı ve kaliteli crash zil arayan müzisyenler için idealdir.\r\n\r\nGenel özellikler\r\n\r\nB20 bronz alaşımı.\r\n\r\nBenzersiz bir ses için elle yapılmıştır."
				},
				new Product
				{
					Id = 37,
					Name = "jinbao m6 keyboard malet",
					ImageUrl = "baget1.png",
					SubCategoryId = 18,
					Url = "jinbao-m6-keyboard-malet",
					Price = 101,
					IsHome = false,
					BrandId = 4,
					Description = "109052178504/Jinbao/B17JMTC",
					Properties = "Yüksek Kaliteli Malzeme: Dayanıklı ve uzun ömürlü kullanım için yüksek kaliteli malzemelerden üretilmiştir.\r\nErgonomik Tasarım: Rahat bir kavrama ve kullanım sağlayan ergonomik bir tasarıma sahiptir.\r\nÇeşitli Kullanım Alanları: Klavye enstrümanlarıyla uyumlu olarak kullanılabilen çok yönlü bir malet.\r\nHassas Ses Üretimi: Denge ve kontrol sağlayan yapısı sayesinde hassas sesler elde etmek için idealdir."
				},
				 new Product
				 {
					 Id = 38,
					 Name = "meinl brush fixed wire baget",
					 ImageUrl = "baget2.png",
					 SubCategoryId = 18,
					 Url = "meinl-brush-fixed-wire-baget",
					 Price = 1352,
					 IsHome = false,
					 BrandId = 4,
					 Description = "109082170035/MEINL/SB302",
					 Properties = "Yüksek Kaliteli Malzeme: Dayanıklı ve uzun ömürlü kullanım için yüksek kaliteli malzemelerden üretilmiştir.\r\nErgonomik Tasarım: Rahat bir kavrama ve kullanım sağlayan ergonomik bir tasarıma sahiptir.\r\nÇeşitli Kullanım Alanları: Klavye enstrümanlarıyla uyumlu olarak kullanılabilen çok yönlü bir malet.\r\nHassas Ses Üretimi: Denge ve kontrol sağlayan yapısı sayesinde hassas sesler elde etmek için idealdir."
				 }

				);
		}
	}
}
