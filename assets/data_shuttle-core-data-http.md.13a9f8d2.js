import { _ as _export_sfc, o as openBlock, c as createElementBlock, d as createStaticVNode } from "./app.7be1e3d0.js";
const __pageData = JSON.parse('{"title":"Shuttle.Core.Data.Http","description":"","frontmatter":{},"headers":[{"level":2,"title":".Net Core 2.0+","slug":"net-core-2-0","link":"#net-core-2-0","children":[]}],"relativePath":"data/shuttle-core-data-http.md"}');
const _sfc_main = { name: "data/shuttle-core-data-http.md" };
const _hoisted_1 = /* @__PURE__ */ createStaticVNode('<h1 id="shuttle-core-data-http" tabindex="-1">Shuttle.Core.Data.Http <a class="header-anchor" href="#shuttle-core-data-http" aria-hidden="true">#</a></h1><div class="language-"><button class="copy"></button><span class="lang"></span><pre><code><span class="line"><span style="color:#A6ACCD;">PM&gt; Install-Package Shuttle.Core.Data.Http</span></span>\n<span class="line"><span style="color:#A6ACCD;"></span></span></code></pre></div><p>Provides the <code>ContextDatabaseContextCache</code> implementation of the <code>IDatabaseContextCache</code> interface for use in web/wcf scenarios:</p><div class="language-"><button class="copy"></button><span class="lang"></span><pre><code><span class="line"><span style="color:#A6ACCD;">services.AddHttpDatabaseContextCache();</span></span>\n<span class="line"><span style="color:#A6ACCD;"></span></span></code></pre></div><h2 id="net-core-2-0" tabindex="-1">.Net Core 2.0+ <a class="header-anchor" href="#net-core-2-0" aria-hidden="true">#</a></h2><p>In order to gain access to the relevant <code>HttpContext</code> you also need to register the following:</p><div class="language-c#"><button class="copy"></button><span class="lang">c#</span><pre><code><span class="line"><span style="color:#A6ACCD;">services</span><span style="color:#89DDFF;">.</span><span style="color:#82AAFF;">AddSingleton</span><span style="color:#89DDFF;">&lt;</span><span style="color:#FFCB6B;">IHttpContextAccessor</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">HttpContextAccessor</span><span style="color:#89DDFF;">&gt;();</span></span>\n<span class="line"></span></code></pre></div>', 7);
const _hoisted_8 = [
  _hoisted_1
];
function _sfc_render(_ctx, _cache, $props, $setup, $data, $options) {
  return openBlock(), createElementBlock("div", null, _hoisted_8);
}
const shuttleCoreDataHttp = /* @__PURE__ */ _export_sfc(_sfc_main, [["render", _sfc_render]]);
export {
  __pageData,
  shuttleCoreDataHttp as default
};
