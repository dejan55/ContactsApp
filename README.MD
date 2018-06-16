<p align="center">
    <img width=40% src="img/ContactApp_logo.jpg?raw=true" alt="Лого на апликацијата/Application logo">
</p>

<h1 align="center">ContactsApp</h1>
<p align="center">Модерна апликација за менаџирање на контакти и испраќање на <b>*бесплатни</b> SMS пораки</p>
<p align="center">Modern application for managing contacts and sending <b>*free</b> SMS</p>

<div align="center">
    <h3>
        <span><a href="#Содржина">Македонски</a></span>
        <span>&nbsp;|&nbsp;<span>
        <span><a href="#table-of-contents">English</a></span>
    </h3>
</div>

---

<br>

## Содржина

- [Карактеристики](#Карактеристики)
- [Краток опис на апликацијата](#Краток-опис-на-апликацијата)
- [Упатство за користење](#Упатство-за-користење)
- [Користени библиотеки/сервиси](#Користени-библиотекисервиси)

<br>

## Карактеристики
- Модерен интерфејс и темна тема за полесно користење на апликацијата
- Лесен и едноставен начин на менаџирање и пребарување на вашите контакти
- Преглед на детали за контактот
- **Импортирање** на конктати од *vCard (.vcf)* датотека
- **Експортирање** на контактите во *vCard (.vcf)* датотека
- **Бесплатно** испраќање на SMS пораки
- Преглед на испратените пораки до секој контакт

<br>

## Краток опис на апликацијата
Оваа именик-апликација е намената за менаџирање на контакти. За полесна употреба во неа е имплементиран лесен и јасен интерфејс за користење. Темната тема на интерфејсот е соодветна и при дневна и при ноќна светлина. Апликацијата исто така нуди можност за испраќање на **бесплатни SMS пораки** до контактите кои што ги имате зачувано во именикот. Испраќањето на SMS пораките се одвива преку веб сервисот <a href="https://www.textlocal.com" target="_blank"><i>TextLocal</i></a>. Важно е да се напомене дека успешното праќање на бесплатната SMS порака повлекува имање на **интернет конекција** и **ненадминување на лимитот** дефиниран од веб сервисот. Апликацијата нуди можност за прегледување и измена на деталите за контактот, како и негово отстранување од именикот, и преглед на историјата на пратени пораки до контактот. Во апликацијата е имплементирано импортирање и експортирање на контактите во стандарден, *vCard (.vcf)*, формат. Исто така, за обезбедување на подобро корисничко искуство со апликацијата, е имплементирана **_бинарна серијализација_** на контактите во скриена (hidden) датотека во директориумот на апликацијата (*C:\Users\\\*username\*\Documents\ContactsApp*). 

<br>

## Упатство за користење

### 1. Опис на формите во апликацијата
При уклучувањето на апликацијата, во средината на екранот, се појавува главниот прозорец на апликацијата кој е прикажан на Слика 1.

<p align="center">
    <img width=40% src="img/slika1.jpg?raw=true" alt="Главен прозорец"> <br>
    <i>Слика 1: Главен прозорец на апликацијата</i>
</p>

Овде на корисникот му се прикажуваат сите контакти кои што ги има, доколку нема внесено се прикажува соодветната лабела, како и поле за пребарување и копче за додавање на нов контакт. Полето за пребарување е оневозможено доколку нема додадено ниеден контакт во листата.
Во рамките на главниот прозорец, на почетниот дел е прикажано мени со 3 подкатегории (*File, Edit, Help*) чии функционалности се прикажани во продолжение.

<p align="center">
    <img width=20% src="img/slika2.jpg?raw=true" alt="File мени"> 
    <img width=30% src="img/slika3.jpg?raw=true" alt="Edit мени">
    <img width=20% src="img/slika4.jpg?raw=true" alt="Help мени"> <br>
    <span><i>Слика 2, 3, 4: Функционалности на менито</i></span>
</p>

Исто така експортирањето и бришењето на сите контакти се оневозможени доколку нема контакти во листата.

Со клик на копчето *Add Contact* се отвара нова форма (Слика 5) во која во означените полиња се внесуваат податоците за контактот и опционално се внесува E-mail адреса и се избира слика. 

<p align="center">
    <img width=30% src="img/slika5.jpg?raw=true" alt="Форма за нов контакт"> <br>
    <span><i>Слика 5: Форма за додавање на нов контакт</i></span>
</p>

На секое поле е додадена валидација со помош на *ErrorProvider* контрола во случај ако задолжителни податоци недостасуваат или не се внесени во точниот формат. 

При клик на контакт (Слика 6) се отвара нова форма во која се прикажани деталите за корисникот и 3 копчиња.

<p align="center">
    <img width=30% src="img/slika1-1.jpg?raw=true" alt="Избор на контакт"> 
    <img width=30% src="img/slika7.jpg?raw=true" alt="Детали за избраниот контакт">
    <img width=30% src="img/slika7-1.jpg?raw=true" alt="Промена на деталите за контактот"> <br>
    <span><i>Слика 6: Избор на контакт и отварање на формата со деталите за контактот и нивна промена</i></span>
</p>

Прикажаните копчиња овозможуваат **бришење на контактот, преглед и праќање на SMS пораки**. Со двоен лев клик на некое од полињата се влегува во **режим на промена** и сите други полиња и копчиња се оневозможени се додека не се кликне прикажаното копче Save за зачувување на промената. Исто така и за овие полиња е додадена валидација со помош на *ErrorProvider* контролата.

Со клик на копчето *Send a message*, на корисникот му се прикажува форма (Слика 7) во која го внесува **испраќачот** во првото поле, а додека во второто поле ја внесува **пораката**.

<p align="center">
    <img width=30% src="img/slika8.jpg?raw=true" alt="Форма за праќање на SMS порака"> <br>
    <span><i>Слика 7: Форма за праќање на SMS порака</i></span>
</p>

Пораката се испраќа со клик на копчето *Send* и се добива соодветен одговор дали праќањето е успешно или не.

Испратените пораки, на корисникот, му се прикажуваат со клик на копчето *Sent messages* каде што во нова форма (Слика 8) се листаат сите пораки кои што се пратени до тој контакт. Исто така при избор на некоја порака, во нов поглед, се прикажуваат информациите за неа (Слика 8).

<p align="center">
    <img width=30% src="img/slika9.jpg?raw=true" alt="Приказ на лабела кога нема пратено пораки до контактот"> 
    <img width=30% src="img/slika9-1.jpg?raw=true" alt="Листање на пратените пораки"> 
    <img width=30% src="img/slika9-2.jpg?raw=true" alt="Детали за избраната порака"> <br>
    <span><i>Слика 8: Форма за листање на пратените пораки и прикажување на детали за порака</i></span>
</p>

Дополнително, на корисникот му е дозволено да ја избрише пораката од листата на пратени пораки.

### 2. Опис на имплементацијата
За чување на контактите, е употребена мапа `SortedDictionary<char, HashSet<ContactEntry>>()` во која **клучевите** се карактери (букви од азбуката) а **вредностите** се множества `HashSet` од тип `ContactEntry`. Уникатноста во рамките на едно множество е обезбедена со `IEqualityComparer<ContactEntry> TelephoneComparer` кој што обезбедува уникатност по телефонскиот број на контактите. Исто така е обезбедена и уникатност на контактите во целата мапа со помош на методот *IsDuplicate()* чија имплементација е следната:

```c#
private bool IsDuplicate(string number, bool importing = false)
{
    foreach (var entry in Contacts)
    {
        foreach (var usr in entry.Value)
        {
            if (usr.TelephoneNumber.Equals(number))
            {
                if (!importing)
                    MessageBox.Show(
                        "You have this number saved with different name.\n" +
                        $"Here are the informations: {usr} {usr.TelephoneNumber}",
                        "Found duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
            }
        }
    }
    
    return false;
}
```

Импортирањето и експортирањето на контактите е направено со помош на библиотеката **MixERP.Net.VCards**. Импортирањето најпрво започнува со избор на датотеката која што ќе се импортира со помош на **OpenFileDialog**:
```c#
var dialog = new OpenFileDialog();
dialog.Filter = "VCard files (*.vcf) | *.vcf";
dialog.Title = "Choose a VCard file to import";

if (dialog.ShowDialog() == DialogResult.OK)
{
    vcardPath = dialog.FileName;
    Console.WriteLine($"[{vcardPath}] was picked.");
}
else
{
    Console.WriteLine("File choosing was canceled!");
    return;
}
```

Потоа, избраната датотека се парсира со помош на библиотеката чиј метод, како резултат, враќа `IEnumerable<VCard>`. Од вратениот резултат, со изминување на колекцијата, се креираат контактите

```c#
ContactEntry contact = null;
.
.
.
contact = new ContactEntry()
{
    FirstName = DecodeQuotedPrintable(vcard.FirstName.Trim()),
    LastName = DecodeQuotedPrintable(vcard.LastName.Trim()),
    TelephoneNumber = number.Trim(),
    Email = email.EmailAddress.Trim(),
    ImageBase64 = photoString
};
```
а потоа и се додаваат во мапата од контакти

```c#
.
.
.
if (Contacts.ContainsKey(key))
{
    Contacts[key].Add(contact);
}
else
{
    Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
    Contacts[key].Add(contact);
}

```

Помошниот методот **DecodeQuotedPrintable()** со имплементација

```c#
public string DecodeQuotedPrintable(string encoded)
{
    if (!Regex.IsMatch(encoded, @"^(=[0-9a-f]{2}){1,}", RegexOptions.IgnoreCase))
        return encoded;

    var output = new List<byte>();

    for (int i = 0; i < encoded.Length; i++)
    {
        if (encoded[i] == '=')
        {
            var sHex = encoded.Substring(i + 1, 2);
            var hex = Convert.ToInt32(sHex, 16);
            var b = Convert.ToByte(hex);
            output.Add(b);
            i += 2;
        }
    }

    return Encoding.UTF8.GetString(output.ToArray());
}
```

врши декодирање на **специјалните знаци** (мак азбука и други non-ASCII карактери) кои што енкодирани во *QuotedPrintable* формат.

При експортирање, најпрво се врши проверка (и креирање) доколку работниот фолдер на апликацијата не постои. Потоа, се изминуват сите контакти од кои се креира објект од класата `VCard` кој подоцна ќе биде искористен од библиотеката за да се запише контактот во датотеката.

```c#
var vcard = new VCard()
{
    Version = VCardVersion.V2_1,
    FirstName = contact.FirstName,
    LastName = contact.LastName,
    Telephones = new List<Telephone>()
    {
        new Telephone()
        {
            Number = contact.TelephoneNumber,
            Type = TelephoneType.Cell
        }
    },
    Emails = new List<Email>()
    {
        new Email()
        {
            EmailAddress = contact.Email,
            Type = EmailType.Smtp
        }
    },
    Photo = new Photo(true, "JPEG", contact.ImageBase64)
};
```

Испраќањето на SMS пораката се прави преку **HTTP/S** протоколот и се комуницира со веб сервисот *TextLocal*. Најпрво се крера URL адресата

```c#
var number = $"00389 {SelectedContact.TelephoneNumber.Substring(1)}";
Message = txtMessage.Text;
Sender = txtBoxSender.Text.Trim();

var url =
    "https://api.txtlocal.com/send/?" +
    "apikey=" + ApiKey +
    "&numbers=" + number +
    "&message=" + Message +
    "&sender=" + Sender;
```

со соодветната порака, испраќач и број на која се испраќа *HTTP PUSH барање* до веб сервисот.

```c#
.
.
.
objRequest.Method = "POST";
objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
objRequest.ContentType = "application/x-www-form-urlencoded";

try
{
    using (var myWriter = new StreamWriter(objRequest.GetRequestStream()))
    {
        myWriter.Write(url);
    }
    Date = DateTime.Now;
}
.
.
.
```
Добиениот *HTTP одговор* се запишува во променливата `string result`

```c#
var objResponse = objRequest.GetResponse() as HttpWebResponse;
if (objResponse == null)
    return string.Empty;

using (var sr = new StreamReader(objResponse.GetResponseStream()))
{
    result = sr.ReadToEnd();
}
```

<br>

## Користени библиотеки/сервиси
Во рамките на нашиот проект беа искористени една надворешна библиотека (**MixERP.Net.VCards** како NuGet пакет) и еден веб сервис (**TextLocal**).

1. <a href="https://github.com/mixerp/MixERP.Net.VCards" target="_blank"><b>MixERP.Net.VCards</b></a> - за импортирање/експортирање на контактите
2. <a href="https://www.textlocal.com" target="_blank"><b>TextLocal</b></a> - за испраќање на SMS пораки

<br>

**Изработено од:**
1. [Костадин Крстев](https://github.com/krstevkoki) 161 169
2. [Јован Наков](https://github.com/jovannakov) 161 195

<p><i>*Бесплатните SMS пораки се лимитирани на приближно 20 од страна на веб сервисот за праќање на истите</i></p>

---
---
## Table of Contents

- [Features](#features)
- [Brief description of the application](#brief-description-of-the-application)
- [User manual](#user-manual)
- [Third-party libraries/services](#third-party-librariesservices)

<br>

## Features
- Modern interface and dark theme for better usability
- Simple and easy way for managing and searching your contacts
- Contact details overview
- **Import** contacts from *vCard (.vcf)* file
- **Export** contacts to *vCard (.vcf)* file
- Send **Free** SMS
- Sent messages overview for every contact

<br>

## Brief description of the application
This contacts-application is intended for managing contacts. For easier use, an easy and clean interface is implemented. The dark theme of the interface is appropriate for both daylight and night light. The application also offers the option of sending **free SMS** to the contacts that you have stored in the contact list. Sending SMS takes place via the <a href="https://www.textlocal.com" target="_blank"><i>TextLocal</i></a> web service. It is important to note that the successful sending of a free SMS entails the existence of an **Internet connection** and **not exceeding the limit** defined by the web service. The application provides the ability to view and edit contact details, as well as remove it from the contact list, and view the history of sent messages to the contact. In the application, importing and exporting contacts in standard, *vCard (.vcf)* format, is implemented. Also, in order to provide a better user experience with the application, **_binary serialization_** of the contacts is implemented in a hidden file in the application directory (*C:\Users\\\*username\*\Documents\ContactsApp*). 
<br>

## User manual

### 1. Description of the forms in the application
When the application is started, in the middle of the screen, the main application window appears, which is shown in Figure 1.

<p align="center">
    <img width=40% src="img/slika1.jpg?raw=true" alt="Main window"> <br>
    <i>Figure 1: Main application window</i>
</p>

Here the user is shown all the contacts that he/she has, if no contacts are added a corresponding label is displayed, a search box and a button to add a new contact. The search field is disabled if no contact has been added to the list. Within the main window, the home screen shows a menu of 3 subcategories (*File, Edit, Help*) whose functions are shown below.

<p align="center">
    <img width=20% src="img/slika2.jpg?raw=true" alt="File menu"> 
    <img width=30% src="img/slika3.jpg?raw=true" alt="Edit menu">
    <img width=20% src="img/slika4.jpg?raw=true" alt="Help menu"> <br>
    <span><i>Figure 2, 3, 4: Menu functions</i></span>
</p>

Also, exporting and deleting all contacts is disabled if there are no contacts in the list.

By clicking on the *Add Contact* button, a new form is opened (Figure 5) in which the contact information is entered in the marked fields and, optionally, an e-mail address is entered or an image is selected.

<p align="center">
    <img width=30% src="img/slika5.jpg?raw=true" alt="New contact form"> <br>
    <span><i>Figure 5: New contact form</i></span>
</p>

Validation is added to each field using *ErrorProvider* control, in case the mandatory data is missing or not entered in the correct format.

When clicking on a contact (Figure 6), a new form is displayed showing user details and 3 buttons.

<p align="center">
    <img width=30% src="img/slika1-1.jpg?raw=true" alt="Choosing contact"> 
    <img width=30% src="img/slika7.jpg?raw=true" alt="Contact details form"> 
    <img width=30% src="img/slika7-1.jpg?raw=true" alt="Editing contact"> <br>
    <span><i>Figure 6: Choosing a contact and opening the form with contact details and editing them</i></span>
</p>

The displayed buttons allow **to delete the contact, view and send SMS messages**. Double-click on one of the fields enters **editing mode** and all other fields and buttons are disabled until the displayed *Save* button is clicked to save the changes. Also, validation is added to these fields by using the *ErrorProvider* control.

By clicking the *Send a message* button, the user is presented with a form (Figure 7) in which the **sender** is entered in the first field, while in the second field the **message** is entered.

<p align="center">
    <img width=30% src="img/slika8.jpg?raw=true" alt="Send SMS form"> <br>
    <span><i>Figure 7: Send a SMS Form</i></span>
</p>

The message is sent by clicking the *Send* button and getting the appropriate answer whether the sending is successful or not.

Sent messages, to the user are displayed, by clicking the *Sent messages* button where in the new form (Figure 8) are listed all messages that are sent to that contact. Also, when selecting a message, the information about it is displayed in a new view (Figure 8).

<p align="center">
    <img width=30% src="img/slika9.jpg?raw=true" alt="Label showing when no messages are sent">
    <img width=30% src="img/slika9-1.jpg?raw=true" alt="Listing sent messages">
    <img width=30% src="img/slika9-2.jpg?raw=true" alt="Message details"> <br>
    <span><i>Figure 8: A form for listing sent messages and displaying message details</i></span>
</p>

Additionally, the user is allowed to delete the message from the list of sent messages.

### 2. Description of the implementation
For contacts storing, a `SortedDictionary<char, HashSet <ContactEntry>>()` map is used, in which **keys** are characters (alphabet letters) and **values** are `HashSet` sets of type `ContactEntry`. The uniqueness within a set is provided by `IEqualityComparer<ContactEntry> TelephoneComparer`, which ensures the uniqueness of the phone number of the contacts. It is also ensured the uniqueness of contacts in the entire map using the *IsDuplicate()* method, whose implementation is given below:

```c#
private bool IsDuplicate(string number, bool importing = false)
{
    foreach (var entry in Contacts)
    {
        foreach (var usr in entry.Value)
        {
            if (usr.TelephoneNumber.Equals(number))
            {
                if (!importing)
                    MessageBox.Show(
                        "You have this number saved with different name.\n" +
                        $"Here are the informations: {usr} {usr.TelephoneNumber}",
                        "Found duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
            }
        }
    }
    
    return false;
}
```

Importing and exporting contacts is done with the help of the library **MixERP.Net.VCards**. The importing starts with the selection of the file that will be imported using **OpenFileDialog**:

```c#
var dialog = new OpenFileDialog();
dialog.Filter = "VCard files (*.vcf) | *.vcf";
dialog.Title = "Choose a VCard file to import";

if (dialog.ShowDialog() == DialogResult.OK)
{
    vcardPath = dialog.FileName;
    Console.WriteLine($"[{vcardPath}] was picked.");
}
else
{
    Console.WriteLine("File choosing was canceled!");
    return;
}
```

Then, the selected file is parsed using a library whose method returns `IEnumerable<VCard>` as a result. From the returned result, with iteration, contacts are created

```c#
ContactEntry contact = null;
.
.
.
contact = new ContactEntry()
{
    FirstName = DecodeQuotedPrintable(vcard.FirstName.Trim()),
    LastName = DecodeQuotedPrintable(vcard.LastName.Trim()),
    TelephoneNumber = number.Trim(),
    Email = email.EmailAddress.Trim(),
    ImageBase64 = photoString
};
```
and then are added to the map.

```c#
.
.
.
if (Contacts.ContainsKey(key))
{
    Contacts[key].Add(contact);
}
else
{
    Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
    Contacts[key].Add(contact);
}

```

Auxiliary method **DecodeQuotedPrintable()** with implementation:

```c#
public string DecodeQuotedPrintable(string encoded)
{
    if (!Regex.IsMatch(encoded, @"^(=[0-9a-f]{2}){1,}", RegexOptions.IgnoreCase))
        return encoded;

    var output = new List<byte>();

    for (int i = 0; i < encoded.Length; i++)
    {
        if (encoded[i] == '=')
        {
            var sHex = encoded.Substring(i + 1, 2);
            var hex = Convert.ToInt32(sHex, 16);
            var b = Convert.ToByte(hex);
            output.Add(b);
            i += 2;
        }
    }

    return Encoding.UTF8.GetString(output.ToArray());
}
```

decodes **special characters** (Macedonian alphabet and other non-ASCII characters) encoded in *QuotedPrintable* format.

When exporting, first a check (and creation) is done for the application's working directory. Then, the contacts in the map are iterated from which a `VCard` object is created, which will later be used by the library to write the contact in the file.

```c#
var vcard = new VCard()
{
    Version = VCardVersion.V2_1,
    FirstName = contact.FirstName,
    LastName = contact.LastName,
    Telephones = new List<Telephone>()
    {
        new Telephone()
        {
            Number = contact.TelephoneNumber,
            Type = TelephoneType.Cell
        }
    },
    Emails = new List<Email>()
    {
        new Email()
        {
            EmailAddress = contact.Email,
            Type = EmailType.Smtp
        }
    },
    Photo = new Photo(true, "JPEG", contact.ImageBase64)
};
```

Sending the SMS is done through the **HTTP/S** protocol for communication with the web service *TextLocal*. First, the URL is created

```c#
var number = $"00389 {SelectedContact.TelephoneNumber.Substring(1)}";
Message = txtMessage.Text;
Sender = txtBoxSender.Text.Trim();

var url =
    "https://api.txtlocal.com/send/?" +
    "apikey=" + ApiKey +
    "&numbers=" + number +
    "&message=" + Message +
    "&sender=" + Sender;
```

with the corresponding message, the sender and the number to which the *HTTP PUSH Request* is sent to the web service.

```c#
.
.
.
objRequest.Method = "POST";
objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
objRequest.ContentType = "application/x-www-form-urlencoded";

try
{
    using (var myWriter = new StreamWriter(objRequest.GetRequestStream()))
    {
        myWriter.Write(url);
    }
    Date = DateTime.Now;
}
.
.
.
```

The received *HTTP Response* is written to the `string result` variable

```c#
var objResponse = objRequest.GetResponse() as HttpWebResponse;
if (objResponse == null)
    return string.Empty;

using (var sr = new StreamReader(objResponse.GetResponseStream()))
{
    result = sr.ReadToEnd();
}
```

<br>

## Third-party libraries/services
Within our project, we used one third-party library (**MixERP.Net.VCards** as a NuGet package) and one web service (**TextLocal**).

1. <a href="https://github.com/mixerp/MixERP.Net.VCards" target="_blank"><b>MixERP.Net.VCards</b></a> - import/export for the contacts
2. <a href="https://www.textlocal.com" target="_blank"><b>TextLocal</b></a> - for SMS sending

**Made by:**
1. [Kostadin Krstev](https://github.com/krstevkoki) 161 169
2. [Jovan Nakov](https://github.com/jovannakov) 161 195

<p><i>*Free SMS is limited to approximately 20 by the web service used for sending them<i></p>
