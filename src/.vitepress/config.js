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
                text: 'Configuration',
                link: '/infrastructure/shuttle-core-configuration'
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
                text: 'TimeSpanTypeConverters',
                link: '/infrastructure/shuttle-core-timespantypeconverters'
            },
            {
                text: 'Transactions',
                link: '/infrastructure/shuttle-core-transactions'
            },
            {
                text: 'Uris',
                link: '/infrastructure/shuttle-core-uris'
            },
        ]
    }
];

const container = [
    {
        text: 'Overview',
        items: [
            {
                text: 'Shuttle.Core.Container',
                link: '/container/shuttle-core-container'
            },
        ]
    },
    {
        text: 'Implementations',
        items: [
            {
                text: 'Autofac',
                link: '/container/shuttle-core-autofac'
            },
            {
                text: 'Castle',
                link: '/container/shuttle-core-castle'
            },
            {
                text: 'Ninject',
                link: '/container/shuttle-core-ninject'
            },
            {
                text: 'SimpleInjector',
                link: '/container/shuttle-core-simpleinjector'
            },
            {
                text: 'StructureMap',
                link: '/container/shuttle-core-structuremap'
            },
            {
                text: 'Unity',
                link: '/container/shuttle-core-unity'
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
            {
                text: 'Dependency Injection',
                link: '/data/shuttle-core-data-di'
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

const logging = [
    {
        text: 'Logging',
        items: [
            {
                text: 'Shuttle.Core.Logging',
                link: '/logging/shuttle-core-logging'
            },
        ]
    },
    {
        text: 'Implementations',
        items: [
            {
                text: 'Log4Net',
                link: '/logging/shuttle-core-log4net'
            },
            {
                text: 'Microsoft Extensions Logging',
                link: '/logging/shuttle-core-microsoft'
            },
        ]
    }
]

const serialization = [
    {
        text: 'Serialization',
        items: [
            {
                text: 'Shuttle.Core.Data',
                link: '/serialization/shuttle-core-serialization'
            },
        ]
    },
    {
        text: 'Implementations',
        items: [
            {
                text: 'Newtonsoft.Json',
                link: '/serialization/shuttle-core-json'
            },
        ]
    }
]

const serviceHosting = [
    {
        text: 'Service Hosting',
        items: [
            {
                text: 'Worker Service',
                link: '/service-hosting/shuttle-core-workerservice'
            },
            {
                text: 'Service Host (Obsolete)',
                link: '/service-hosting/shuttle-core-servicehost'
            },
            {
                text: 'Host (Obsolete)',
                link: '/service-hosting/shuttle-core-host'
            },
        ]
    },
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
            // algolia: {
            //     indexName: 'Shuttle.Core Documentation',
            //     appId: '42GX712C20',
            //     apiKey: 'cc059819a5d38ee7a55298f7cf9ed70a'
            // },

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
                    text: 'Container',
                    activeMatch: `^/container/`,
                    link: '/container/shuttle-core-container'
                },
                {
                    text: 'Data',
                    activeMatch: `^/data/`,
                    link: '/data/shuttle-core-data'
                },
                {
                    text: 'Logging',
                    activeMatch: `^/logging/`,
                    link: '/logging/shuttle-core-logging'
                },
                {
                    text: 'Serialization',
                    activeMatch: `^/serialization/`,
                    link: '/serialization/shuttle-core-serialization'
                },
                {
                    text: 'Service Hosting',
                    activeMatch: `^/service-hosting/`,
                    link: '/service-hosting/shuttle-core-workerservice'
                },
            ],

            sidebar: {
                '/infrastructure/': infrastructure,
                '/container/': container,
                '/data/': data,
                '/logging/': logging,
                '/serialization/': serialization,
                '/service-hosting/': serviceHosting,
            }
        },
    };
})()
