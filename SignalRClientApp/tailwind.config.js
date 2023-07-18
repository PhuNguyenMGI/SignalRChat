/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './src/components/**/*.{js,vue,ts}',
    './src/layouts/**/*.vue',
    './src/pages/**/*.vue',
    './src/views/**/*.vue',
    './src/plugins/**/*.{js,ts}',
    './src/app.vue',
    './index.html',
  ],
  theme: {
    screens: {
      xxs: '320px',
      xs: '480px',
      sm: '640px',
      md: '768px',
      xmd: '880px',
      lg: '1024px',
      xlg: '1170px',
      xl: '1280px'
    },
    extend: {
      colors: {
        'gray-lighter': '#F4F4F4',
        'gray-light': '#D3D6D7',
        'gray-base': '#A9AEB1',
        'gray-dark': '#7E868A',
        'gray-darker': '#545E64',
        'gray-darkest': '#2A363E',
        black: '#000',
        white: '#FFF',
        transparent: 'transparent',
        'primary-cta': {
          '5': '#FFFAF5',
          '10': '#FEF4EA',
          '20': '#FDEBD7',
          '40': '#FCD8B0',
          '60': '#FBC58A',
          '80': '#FAB263',
          '100': '#F99F3D',
        },
        secondary: {
          'ripple': '#D9EEF2',
          '5': '#F2F9FB',
          '10': '#E5F4F6',
          '20': '#CCE9EE',
          '40': '#99D3DC',
          '60': '#66BDCB',
          '80': '#33A7B9',
          '100': '#0091A8',
        },
        "secondary-a": {
          '5': '#FFF7F4',
          '10': '#FFEFE9',
          '20': '#FFE0D5',
          '40': '#FEC1AB',
          '60': '#FDA281',
          '80': '#FC8357',
          '100': '#fc642d',
        },
        success: {
          '5': '#F4FDF9',
          '10': '#EAFBF3',
          '20': '#D6F6E7',
          '40': '#ADEDCF',
          '60': '#84E3B7',
          '80': '#5BDA9F',
          '100': '#33D188',
        },
        warning: {
          '5': '#F9F7F2',
          '10': '#F3EEE6',
          '20': '#E8DECF',
          '40': '#D2BE9F',
          '60': '#BB9D6F',
          '80': '#A47D3F',
          '100': '#8E5D0F',
        },
        error: {
          '5': '#FDF5F5',
          '10': '#F9EAEA',
          '20': '#F4D6D6',
          '40': '#EAAEAE',
          '60': '#DF8787',
          '80': '#D55F5F',
          '100': '#CB3838',
        }

      },
      // boxShadow: {
      //   base: '0px 2px 3px rgba(0, 0, 0, 0.16)',
      // },
      // keyframes: {
      //   wiggle: {
      //     '0%': { transform: 'rotate(0deg)' },
      //     '50%': { transform: 'rotate(180deg)' },
      //     '100%': { transform: 'rotate(360deg)' },
      //   },
      // },
      // animation: {
      //   wiggle: 'wiggle 2s ease-in-out infinite',
      // },
    },
  },
  plugins: [],
}
