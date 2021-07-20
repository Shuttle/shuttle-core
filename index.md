---
layout: default
title: Shuttle.Core documentation
tagline: cross-cutting assemblies that facilitate the development of .net software
---
<div class='overview display-4'>Cross-cutting packages that are used to facilitate the development of .Net software.</div>
<br/>
<div class="card">
    <div class="card-body lead">
        These components are used extensively in other repositories such as the <a href='http://shuttle.github.io/shuttle-esb/' target='_blank'>Shuttle.Esb</a> and <a href='http://shuttle.github.io/shuttle-recall/' target='_blank'>Shuttle.Recall</a> projects.
    </div>
</div>
<br/>
<div class="alert alert-success" role="alert">
    Packages currently target <code class="language-plaintext">netstandard2.0</code> and <code class="language-plaintext">netstandard2.1</code> which means that the libraries can be used with the following runtimes:
    <ul>
        <li>.NET Core 2.1+</li>
        <li>.NET Framework 4.6.1+</li>
        <li>.NET 5.0</li>
    </ul>
</div>

{% capture include-index %}{% include index.md %}{% endcapture %}
{{ include-index | markdownify }}

