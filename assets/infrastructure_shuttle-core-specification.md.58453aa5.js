import { _ as _export_sfc, c as createElementBlock, o as openBlock, d as createStaticVNode } from "./app.e654cdbe.js";
const __pageData = '{"title":"Shuttle.Core.Specification","description":"","frontmatter":{},"headers":[],"relativePath":"infrastructure/shuttle-core-specification.md"}';
const _sfc_main = {};
const _hoisted_1 = /* @__PURE__ */ createStaticVNode('<h1 id="shuttle-core-specification" tabindex="-1">Shuttle.Core.Specification <a class="header-anchor" href="#shuttle-core-specification" aria-hidden="true">#</a></h1><div class="language-"><pre><code>PM&gt; Install-Package Shuttle.Core.Specification\n</code></pre></div><p>Provides a simple <code>ISpecification</code> interface.</p><p>A default <code>Specification</code> class is available that accepts a function as a callback for scenarios where an explicit <code>ISpecification</code> implementation may not be warranted:</p><div class="language-c#"><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">Specification</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">Func</span><span style="color:#89DDFF;">&lt;</span><span style="color:#FFCB6B;">T</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">bool&gt;</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">function</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div>', 5);
const _hoisted_6 = [
  _hoisted_1
];
function _sfc_render(_ctx, _cache, $props, $setup, $data, $options) {
  return openBlock(), createElementBlock("div", null, _hoisted_6);
}
var shuttleCoreSpecification = /* @__PURE__ */ _export_sfc(_sfc_main, [["render", _sfc_render]]);
export { __pageData, shuttleCoreSpecification as default };