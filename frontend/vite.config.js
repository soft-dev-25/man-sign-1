import { defineConfig } from 'vite';

export default defineConfig({
    // config options
    base: '/',
    server: {
        port: 8080,
        open: true,
    },
    preview: {
        port: 8080,
        open: true,
    },
});