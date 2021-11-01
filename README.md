<div id="top"></div>
<!--
*** Thanks for checking out the BERTTokenizers for C#. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again!
-->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/NMZivkovic/BertTokenizers">
    <img src="BERTTokenizers/Assets/logo.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">BERTTokenizer for C#</h3>

  <p align="center">
    project_description
    <br />
    ·
    <a href="https://github.com/NMZivkovic/BertTokenizers/issues">Report Bug</a>
    ·
    <a href="https://github.com/NMZivkovic/BertTokenizers/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

While working with BERT Models from Huggingface in combination with ML.NET, I stumbled upon several challenges.
I documented them in [here](https://rubikscode.net/2021/10/25/using-huggingface-transformers-with-ml-net/).</br>
However, the biggest challenge by far was that I needed to implement my own tokenizer and pair them with the correct vocabulary.
So, I decided to extend it and publish my implementation as an open-source project.

This repository contains tokenizers for following models:<br />
    · BERT Base<br />
    · BERT Large<br />
    · BERT German<br />
    · BERT Multilingual<br />
    · BERT Base Uncased<br />
    · BERT Large Uncased<br />

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

The project is available as NuGet package.

### Installation

To add BERT Tokenizers to your project use dotnet command:

```sh
dotnet add package BERTTokenizers
```

</br>
Or install it with package manager:

```bash
Install-Package BERTTokenizers
```

<!-- USAGE EXAMPLES -->
## Usage

For example, you want to use Huggingface BERT Base Model whose input is defined like this:

```csharp

public class BertInput
{
    [VectorType(1, 256)]
    [ColumnName("input_ids")]
    public long[] InputIds { get; set; }

    [VectorType(1, 256)]
    [ColumnName("attention_mask")]
    public long[] AttentionMask { get; set; }

    [VectorType(1, 256)]
    [ColumnName("token_type_ids")]
    public long[] TypeIds { get; set; }
}

```

For this you need to encode sentences like this:

```csharp

var sentence = "I love you";

var tokenizer = new BertBaseTokenizer();

var encoded = tokenizer.Encode(256, sentence);

var bertInput = new BertInput()
                {
                    InputIds = encoded.InputIds,
                    AttentionMask = encoded.AttentionMask,
                    TypeIds = encoded.TokenTypeIds,
                };

```

_For more examples, please refer to this [Blog Post](https://rubikscode.net/2021/11/01/bert-tokenizers-for-ml-net/)_

See the [open issues](https://github.com/NMZivkovic/BertTokenizers/issues) for a full list of proposed features (and known issues).


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Nikola M. Zivkovic</br>
n.zivkovic@rubikscode.net</br>
[LinkedIn](https://www.linkedin.com/in/nmzivkovic/)</br>
[@NMZivkovic](https://twitter.com/NMZivkovic)</br>

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* Gianluca Bertani - Performance Improvements

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/NMZivkovic/BertTokenizers.svg?style=for-the-badge
[contributors-url]: https://github.com/NMZivkovic/BertTokenizers/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/NMZivkovic/BertTokenizers.svg?style=for-the-badge
[forks-url]: https://github.com/NMZivkovic/BertTokenizers/network/members
[stars-shield]: https://img.shields.io/github/stars/NMZivkovic/BertTokenizers.svg?style=for-the-badge
[stars-url]: https://github.com/NMZivkovic/BertTokenizers/stargazers
[issues-shield]: https://img.shields.io/github/issues/NMZivkovic/BertTokenizers.svg?style=for-the-badge
[issues-url]: https://github.com/NMZivkovic/BertTokenizers/issues
[license-shield]: https://img.shields.io/github/license/NMZivkovic/BertTokenizers.svg?style=for-the-badge
[license-url]: https://github.com/NMZivkovic/BertTokenizers/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/nmzivkovic/
