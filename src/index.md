---
page: true
title: Shuttle.Core
---
<script setup>
import Home from '/@theme/components/Home.vue'
import { useFavicon } from '@vueuse/core'

const icon = useFavicon()

icon.value = '/favicon.ico'
</script>

<Home />

