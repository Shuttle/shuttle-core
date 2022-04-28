import { _ as _export_sfc, o as openBlock, c as createElementBlock, b as createBaseVNode, e as createVNode, u as unref, V as VTIconShuttle, F as Fragment, p as pushScopeId, f as popScopeId, a as createStaticVNode } from "./app.e221d2b0.js";
var Home_vue_vue_type_style_index_0_scoped_true_lang = "";
const _withScopeId = (n) => (pushScopeId("data-v-5bb6e941"), n = n(), popScopeId(), n);
const _hoisted_1 = { id: "hero" };
const _hoisted_2 = /* @__PURE__ */ _withScopeId(() => /* @__PURE__ */ createBaseVNode("h1", { class: "tagline" }, null, -1));
const _hoisted_3 = /* @__PURE__ */ _withScopeId(() => /* @__PURE__ */ createBaseVNode("p", { class: "description" }, " Cross-cutting packages that are used to facilitate the development of .Net software. ", -1));
const _hoisted_4 = /* @__PURE__ */ createStaticVNode('<section id="highlights" class="vt-box-container" data-v-5bb6e941><div class="vt-box" data-v-5bb6e941><h2 data-v-5bb6e941>Framework Support</h2><div data-v-5bb6e941>Packages currently target <code data-v-5bb6e941>netstandard2.0</code> and <code data-v-5bb6e941>netstandard2.1</code> which means that they can be used with .NET Core 2.1+, .NET Framework 4.6.1+, and .NET 5.0+</div></div><div class="vt-box" data-v-5bb6e941><h2 data-v-5bb6e941>Common Patterns</h2><div data-v-5bb6e941>Many common patterns and mechanisms are provided that get you up-and-running quickly.</div></div><div class="vt-box" data-v-5bb6e941><h2 data-v-5bb6e941>Open Source</h2><div data-v-5bb6e941>These packages are free open source software licensed under the <a href="https://opensource.org/licenses/BSD-3-Clause" data-v-5bb6e941>3-Clause BSD License</a>. Pull requests are welcome.</div></div></section>', 1);
const _sfc_main$1 = {
  setup(__props) {
    return (_ctx, _cache) => {
      return openBlock(), createElementBlock(Fragment, null, [
        createBaseVNode("section", _hoisted_1, [
          createVNode(unref(VTIconShuttle), { class: "logo" }),
          _hoisted_2,
          _hoisted_3
        ]),
        _hoisted_4
      ], 64);
    };
  }
};
var Home = /* @__PURE__ */ _export_sfc(_sfc_main$1, [["__scopeId", "data-v-5bb6e941"]]);
const __pageData = '{"title":"Home","description":"","frontmatter":{"page":true,"title":"Home"},"headers":[],"relativePath":"index.md"}';
const __default__ = {};
const _sfc_main = /* @__PURE__ */ Object.assign(__default__, {
  setup(__props) {
    return (_ctx, _cache) => {
      return openBlock(), createElementBlock("div", null, [
        createVNode(Home)
      ]);
    };
  }
});
export { __pageData, _sfc_main as default };
