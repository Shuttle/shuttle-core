<template>
    <div>
        <section id="hero">
            <p class="upgrade-notice">
                The latest version of the Shuttle.Core components now make use of <a
                    href="https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection"
                    target="_blank">.NET dependency injection</a> as well as the <a
                    href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0"
                    target="_blank">options pattern</a>. This is a major departure from the component container adapter
                pattern used to date. Please take a look at the <a href="/shuttle-core/upgrade-ms-di.html">upgrade
                    guide</a> to see the <strong>breaking changes</strong>.
            </p>
            <h1 class="tagline">Useful .Net stuff</h1>
            <p class="description">
                Cross-cutting packages that are used to facilitate the development of .Net software.
            </p>
        </section>

        <section id="highlights" class="vt-box-container">
            <div class="vt-box">
                <h2>Framework Support</h2>
                <div>Packages currently target <code>netstandard2.0</code> and <code>netstandard2.1</code> which means
                    that
                    they can be used with .NET Core 2.1+, .NET Framework 4.6.1+, and .NET 5.0+</div>
            </div>
            <div class="vt-box">
                <h2>Common Patterns</h2>
                <div>Many common patterns and mechanisms are provided that get you up-and-running quickly.</div>
            </div>
            <div class="vt-box">
                <h2>Open Source</h2>
                <div>These packages are free open source software licensed under the <a
                        href='https://opensource.org/licenses/BSD-3-Clause'>3-Clause BSD License</a>. Pull requests are
                    welcome.</div>
            </div>
        </section>
    </div>
</template>

<style scoped>
.upgrade-notice {
    border-radius: 8px;
    max-width: 960px;
    margin: 0px auto;
    color: var(--vt-c-text-2);
    font-size: .9rem;
    border: solid 1px var(--vt-c-divider-dark-1);
    margin-bottom: 2em;
    background-color: var(--vt-c-bg-soft);
}

a {
    color: var(--vt-c-orange-dark);
}

a:hover {
    color: var(--vt-c-orange);
}

.logo {
    height: 15em;
    width: 15em;
    margin: auto;
}

section {
    padding: 42px 32px;
}

#hero {
    padding: 32px 32px;
    text-align: center;
}

.tagline {
    font-size: 76px;
    line-height: 1.25;
    font-weight: 900;
    letter-spacing: -1.5px;
    max-width: 960px;
    margin: 0px auto;
}

html:not(.dark) .accent,
.dark .tagline {
    background: -webkit-linear-gradient(315deg,
            hsl(31, 75%, 52%) 25%,
            hsl(45, 69%, 44%));
    background-clip: text;
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
}

.description {
    max-width: 960px;
    line-height: 1.5;
    color: var(--vt-c-text-2);
    transition: color 0.5s;
    font-size: 22px;
    margin: 24px auto 40px;
}

.actions a {
    font-size: 16px;
    display: inline-block;
    background-color: var(--vt-c-bg-mute);
    padding: 8px 18px;
    font-weight: 500;
    border-radius: 8px;
    transition: background-color 0.5s, color 0.5s;
}

.actions .get-started {
    font-weight: 600;
    background-color: var(--vt-c-orange);
    color: #fff;
    margin-right: 18px;
}

.actions .icon {
    display: inline;
    position: relative;
    top: -1px;
    margin-left: 2px;
    fill: currentColor;
    transition: transform 0.2s;
}

.dark .actions .get-started {
    color: var(--vt-c-indigo);
}

.actions .get-started:hover {
    background-color: var(--vt-c-orange-dark);
    transition-duration: 0.2s;
}

.actions .get-started:hover .icon {
    transform: translateX(2px);
}

.dark .actions .get-started:hover {
    background-color: var(--vt-c-orange-light);
}

.actions .setup {
    color: var(--vt-c-text-code);
}

.actions .setup:hover {
    background-color: var(--vt-c-gray-light-4);
    transition-duration: 0.2s;
}

.dark .actions .setup:hover {
    background-color: var(--vt-c-gray-dark-3);
}

#special-sponsor {
    border-top: 1px solid var(--vt-c-divider-light);
    border-bottom: 1px solid var(--vt-c-divider-light);
    padding: 12px 24px;
    text-align: center;
}

#special-sponsor span {
    color: var(--vt-c-text-2);
    font-weight: 500;
    font-size: 13px;
    vertical-align: middle;
    margin: 0 24px;
}

#special-sponsor img {
    display: inline-block;
    vertical-align: middle;
    height: 36px;
}

.dark #special-sponsor img {
    filter: grayscale(1) invert(1);
}

#highlights {
    max-width: 960px;
    margin: 0px auto;
    color: var(--vt-c-text-2);
}

#highlights h2 {
    font-weight: 600;
    font-size: 20px;
    letter-spacing: -0.4px;
    color: var(--vt-c-text-1);
    transition: color 0.5s;
    margin-bottom: 0.75em;
}

#highlights p {
    font-weight: 400;
    font-size: 15px;
}

#highlights .vt-box {
    background-color: transparent;
}

#sponsors {
    max-width: 900px;
    margin: 0px auto;
}

#sponsors h2 {
    font-size: 20px;
    font-weight: 600;
    margin-bottom: 1em;
}

#sponsors .sponsor-container {
    margin-bottom: 3em;
}

@media (max-width: 960px) {
    .tagline {
        font-size: 64px;
        letter-spacing: -0.5px;
    }

    .description {
        font-size: 18px;
        margin-bottom: 48px;
    }
}

@media (max-width: 768px) {
    .tagline {
        font-size: 48px;
        letter-spacing: -0.5px;
    }
}

@media (max-width: 576px) {
    #hero {
        padding: 64px 32px;
    }

    .description {
        font-size: 16px;
        margin: 18px 0 30px;
    }

    #special-sponsor img {
        display: block;
        margin: 2px auto 1px;
    }

    #highlights h3 {
        margin-bottom: 0.6em;
    }

    #highlights .vt-box {
        padding: 20px 36px;
    }
}

@media (max-width: 370px) {
    .tagline {
        font-size: 36px;
    }
}
</style>
