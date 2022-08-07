const getBase = require('shuttle-theme/config')
const path = require('path')

const infrastructure = [
    {
        text: 'Infrastructure',
        items: [
            {
                text: 'Cli',
                link: '/infrastructure/shuttle-core-cli'
            },
            {
                text: 'Compression',
                link: '/infrastructure/shuttle-core-compression'
            },
            {
                text: 'Contract',
                link: '/infrastructure/shuttle-core-contract'
            },
            {
                text: 'Cron',
                link: '/infrastructure/shuttle-core-cron'
            },
            {
                text: 'Dependency Injection',
                link: '/infrastructure/shuttle-core-dependencyinjection'
            },
            {
                text: 'Encryption',
                link: '/infrastructure/shuttle-core-encryption'
            },
            {
                text: 'Mediator',
                link: '/infrastructure/shuttle-core-mediator'
            },
            {
                text: 'Pipelines',
                link: '/infrastructure/shuttle-core-pipelines'
            },
            {
                text: 'Reflection',
                link: '/infrastructure/shuttle-core-reflection'
            },
            {
                text: 'Specification',
                link: '/infrastructure/shuttle-core-specification'
            },
            {
                text: 'Streams',
                link: '/infrastructure/shuttle-core-streams'
            },
            {
                text: 'System',
                link: '/infrastructure/shuttle-core-system'
            },
            {
                text: 'Threading',
                link: '/infrastructure/shuttle-core-threading'
            },
            {
                text: 'Transactions',
                link: '/infrastructure/shuttle-core-transactions'
            },
        ]
    }
];

const data = [
    {
        text: 'Data',
        items: [
            {
                text: 'Shuttle.Core.Data',
                link: '/data/shuttle-core-data'
            },
        ]
    },
    {
        text: 'Implementations',
        items: [
            {
                text: 'Http',
                link: '/data/shuttle-core-data-http'
            },
        ]
    }
]

const serialization = [
    {
        text: 'Serialization',
        items: [
            {
                text: 'Shuttle.Core.Serialization',
                link: '/serialization/shuttle-core-serialization'
            },
        ]
    },
    {
        text: 'Implementations',
        items: [
            {
                text: 'Json',
                link: '/serialization/shuttle-core-json'
            },
        ]
    }
]

module.exports = (async () => {
    const base = await getBase();

    return {
        ...base,

        vite: {
            ...base.vite,
            build: {
                minify: false
            },
            resolve: {
                alias: {
                    '@vue/theme': path.join(__dirname, '../../src')
                }
            }
        },

        base: '/shuttle-core/',
        lang: 'en-US',
        title: 'Shuttle.Core',
        description: 'Shuttle-Core Documentation',

        head: [
            ...base.head,
            ['link', { rel: "shortcut icon", href: "/shuttle-core/favicon.ico" }]
        ],

        themeConfig: {
            algolia: {
                indexName: 'shuttle',
                appId: '8AVNJSMBZI',
                apiKey: 'a17fbccfc1eca711e2ec7712bfcec46f'
            },

            // carbonAds: {
            //     code: '',
            //     placement: ''
            // },

            socialLinks: [
                { icon: 'github', link: 'https://github.com/Shuttle/shuttle-core' },
                // { icon: 'twitter', link: '' },
                // { icon: 'discord', link: '' }
            ],

            footer: {
                copyright: `Copyright © 2013-${new Date().getFullYear()} Eben Roux`
            },
            
            nav: [
                {
                    text: 'Infrastructure',
                    activeMatch: `^/infrastructure/`,
                    link: '/infrastructure/index'
                },
                {
                    text: 'Data',
                    activeMatch: `^/data/`,
                    link: '/data/shuttle-core-data'
                },
                {
                    text: 'Serialization',
                    activeMatch: `^/serialization/`,
                    link: '/serialization/shuttle-core-serialization'
                },
                {
                    text: 'Hosting',
                    activeMatch: `^/core/`,
                    link: '/core/hosting'
                },
            ],

            sidebar: {
                '/infrastructure/': infrastructure,
                '/data/': data,
                '/serialization/': serialization,
            }
        },
    };
})()
