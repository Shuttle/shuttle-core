import { _ as _export_sfc, c as createElementBlock, o as openBlock, a as createStaticVNode } from "./app.5eee1682.js";
const __pageData = '{"title":"Shuttle.Core.Contract","description":"","frontmatter":{},"headers":[],"relativePath":"infrastructure/shuttle-core-contract.md"}';
const _sfc_main = {};
const _hoisted_1 = /* @__PURE__ */ createStaticVNode('<h1 id="shuttle-core-contract" tabindex="-1">Shuttle.Core.Contract <a class="header-anchor" href="#shuttle-core-contract" aria-hidden="true">#</a></h1><div class="language-"><pre><code>PM&gt; Install-Package Shuttle.Core.Contract\n</code></pre></div><p>A guard implementation that performs assertions/assumptions to prevent invalid code execution.</p><h1 id="guard" tabindex="-1">Guard <a class="header-anchor" href="#guard" aria-hidden="true">#</a></h1><div class="language-c#"><pre><code><span class="line"><span style="color:#89DDFF;">void</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">Against</span><span style="color:#89DDFF;">&lt;</span><span style="color:#FFCB6B;">TException</span><span style="color:#89DDFF;">&gt;(bool</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">assertion</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">message</span><span style="color:#89DDFF;">)</span><span style="color:#A6ACCD;"> </span></span>\n<span class="line"><span style="color:#A6ACCD;">	</span><span style="color:#F78C6C;">where</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">TException</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">:</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">Exception</span></span>\n<span class="line"></span></code></pre></div><p>Throws exception <code>TException</code> with the given <code>message</code> if the <code>assertion</code> is false. If exception type <code>TException</code> does not have a constructor that accepts a <code>message</code> then an <code>InvalidOperationException</code> is thrown instead.</p><hr><div class="language-c#"><pre><code><span class="line"><span style="color:#89DDFF;">void</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">AgainstNull</span><span style="color:#89DDFF;">(object</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">value</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">name</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div><p>Throws a <code>NullReferenceException</code> if the given <code>value</code> is <code>null</code>.</p><hr><div class="language-c#"><pre><code><span class="line"><span style="color:#89DDFF;">void</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">AgainstNullOrEmptyString</span><span style="color:#89DDFF;">(string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">value</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">name</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div><p>Throws a <code>NullReferenceException</code> if the given <code>value</code> is <code>null</code> or empty/whitespace.</p><hr><div class="language-c#"><pre><code><span class="line"><span style="color:#89DDFF;">void</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">AgainstUndefinedEnum</span><span style="color:#89DDFF;">&lt;</span><span style="color:#FFCB6B;">TEnum</span><span style="color:#89DDFF;">&gt;(object</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">value</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">name</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div><p>Throws an <code>InvalidOperationException</code> if the provided <code>value</code> cannot be found in the given <code>enum</code>.</p><hr><div class="language-c#"><pre><code><span class="line"><span style="color:#89DDFF;">void</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">AgainstEmptyEnumerable</span><span style="color:#89DDFF;">&lt;</span><span style="color:#FFCB6B;">T</span><span style="color:#89DDFF;">&gt;(</span><span style="color:#FFCB6B;">IEnumerable</span><span style="color:#89DDFF;">&lt;</span><span style="color:#FFCB6B;">T</span><span style="color:#89DDFF;">&gt;</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">enumerable</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">name</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div><p>Throws an <code>InvalidOperationException</code> if the given <code>enumerable</code> does not contain any entries.</p><hr><div class="language-c#"><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#C792EA;">static</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">void</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">AgainstEmptyGuid</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">Guid</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">value</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">name</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div><p>Throws and <code>ArgumentException</code> when the <code>value</code> is equal to an empty <code>Guid</code> (<code>{00000000-0000-0000-0000-000000000000}</code>).</p>', 21);
const _hoisted_22 = [
  _hoisted_1
];
function _sfc_render(_ctx, _cache, $props, $setup, $data, $options) {
  return openBlock(), createElementBlock("div", null, _hoisted_22);
}
var shuttleCoreContract = /* @__PURE__ */ _export_sfc(_sfc_main, [["render", _sfc_render]]);
export { __pageData, shuttleCoreContract as default };
