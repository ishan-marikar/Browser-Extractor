#  Browser-Extractor #
A simple and easy to use saved password extractor for browsers.
Currently only supports chrome, but stay tuned for more updates.

Feel free to send me a pull request and contribute :3

## How do I use this? ##
    List<Credentials> userCredentials = new List<Credentials>();
    userCredentials.AddRange(LoginReader.GetChromePasswords());

## TODO ##
    
- Retrieve passwords from Mozilla Firefox and Internet Explorer
- Retrieve Chrome history items: 
    - URL
    - Website Title
    - Visit Count
    - Typed Count
    - Last visit time
    - Time spent on site