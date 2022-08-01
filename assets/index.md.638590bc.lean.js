import { _ as _export_sfc, o as openBlock, c as createElementBlock, b as createBaseVNode, d as createVNode, u as unref, V as VTIconShuttle, e as VTIconDiscord, F as Fragment, p as pushScopeId, f as popScopeId, g as createTextVNode, a as createStaticVNode } from "./app.28ec495d.js";
var Home_vue_vue_type_style_index_0_scoped_true_lang = "";
const _withScopeId = (n) => (pushScopeId("data-v-311d3d30"), n = n(), popScopeId(), n);
const _hoisted_1 = { id: "hero" };
const _hoisted_2 = /* @__PURE__ */ _withScopeId(() => /* @__PURE__ */ createBaseVNode("h1", { class: "tagline" }, null, -1));
const _hoisted_3 = /* @__PURE__ */ _withScopeId(() => /* @__PURE__ */ createBaseVNode("p", { class: "description" }, " Cross-cutting packages that are used to facilitate the development of .Net software. ", -1));
const _hoisted_4 = {
  href: "https://discord.gg/57ptMQrpwT",
  target: "_blank"
};
const _hoisted_5 = { class: "discord-link" };
const _hoisted_6 = /* @__PURE__ */ createTextVNode("Join our Discord channel ");
const _hoisted_7 = /* @__PURE__ */ createStaticVNode("", 1);
const _sfc_main$1 = {
  setup(__props) {
    return (_ctx, _cache) => {
      return openBlock(), createElementBlock(Fragment, null, [
        createBaseVNode("section", _hoisted_1, [
          createVNode(unref(VTIconShuttle), { class: "logo" }),
          _hoisted_2,
          _hoisted_3,
          createBaseVNode("p", null, [
            createBaseVNode("a", _hoisted_4, [
              createBaseVNode("div", _hoisted_5, [
                createVNode(unref(VTIconDiscord), { class: "discord-logo" }),
                _hoisted_6
              ])
            ])
          ])
        ]),
        _hoisted_7
      ], 64);
    };
  }
};
var Home = /* @__PURE__ */ _export_sfc(_sfc_main$1, [["__scopeId", "data-v-311d3d30"]]);
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
