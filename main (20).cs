class Circle {
    constructor(radius) {
        this._radius = radius;
    }

    get radius() {
        return this._radius;
    }

    set radius(value) {
        this._radius = value;
    }

    get diameter() {
        return this._radius * 2;
    }

    area() {
        return Math.PI * this._radius * this._radius;
    }

    length() {
        return 2 * Math.PI * this._radius;
    }
}

let circle = new Circle(5);

console.log("Радіус:", circle.radius);
circle.radius = 10;
console.log("Новий радіус:", circle.radius);
console.log("Діаметр:", circle.diameter);
console.log("Площа:", circle.area());
console.log("Довжина:", circle.length());


class HtmlElement {
    constructor(tagName, selfClosing = false, text = "") {
        this.tagName = tagName;
        this.selfClosing = selfClosing;
        this.text = text;
        this.attributes = [];
        this.styles = [];
        this.children = [];
    }

    setAttribute(name, value) {
        this.attributes.push({
            name: name,
            value: value
        });
    }

    setStyle(name, value) {
        this.styles.push({
            name: name,
            value: value
        });
    }

    appendChild(element) {
        this.children.push(element);
    }

    prependChild(element) {
        this.children.unshift(element);
    }

    getHtml() {
        let html = "<" + this.tagName;

        for (let attribute of this.attributes) {
            html += " " + attribute.name + "=\"" + attribute.value + "\"";
        }

        if (this.styles.length > 0) {
            html += " style=\"";

            for (let style of this.styles) {
                html += style.name + ":" + style.value + ";";
            }

            html += "\"";
        }

        if (this.selfClosing) {
            html += ">";
            return html;
        }

        html += ">";

        html += this.text;

        for (let child of this.children) {
            html += child.getHtml();
        }

        html += "</" + this.tagName + ">";

        return html;
    }
}

let wrapper = new HtmlElement("div");
wrapper.setAttribute("id", "wrapper");
wrapper.setStyle("display", "flex");

let block1 = new HtmlElement("div");
block1.setStyle("width", "300px");
block1.setStyle("margin", "10px");

let title1 = new HtmlElement("h3", false, "What is Lorem Ipsum?");

let image1 = new HtmlElement("img", true);
image1.setAttribute("src", "lipsum.jpg");
image1.setAttribute("alt", "Lorem Ipsum");
image1.setStyle("width", "100%");

let text1 = new HtmlElement(
    "p",
    false,
    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."
);

let link1 = new HtmlElement("a", false, "More...");
link1.setAttribute("href", "https://www.lipsum.com/");
link1.setAttribute("target", "_blank");

text1.appendChild(link1);

block1.appendChild(title1);
block1.appendChild(image1);
block1.appendChild(text1);


let block2 = new HtmlElement("div");
block2.setStyle("width", "300px");
block2.setStyle("margin", "10px");

let title2 = new HtmlElement("h3", false, "What is Lorem Ipsum?");

let image2 = new HtmlElement("img", true);
image2.setAttribute("src", "lipsum.jpg");
image2.setAttribute("alt", "Lorem Ipsum");
image2.setStyle("width", "100%");

let text2 = new HtmlElement(
    "p",
    false,
    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."
);

let link2 = new HtmlElement("a", false, "More...");
link2.setAttribute("href", "https://www.lipsum.com/");
link2.setAttribute("target", "_blank");

text2.appendChild(link2);

block2.appendChild(title2);
block2.appendChild(image2);
block2.appendChild(text2);

wrapper.appendChild(block1);
wrapper.appendChild(block2);

document.write(wrapper.getHtml());


class CssClass {
    constructor(name) {
        this.name = name;
        this.styles = [];
    }

    setStyle(name, value) {
        this.styles.push({
            name: name,
            value: value
        });
    }

    removeStyle(name) {
        this.styles = this.styles.filter(function(style) {
            return style.name != name;
        });
    }

    getCss() {
        let css = "." + this.name + " {";

        for (let style of this.styles) {
            css += style.name + ":" + style.value + ";";
        }

        css += "}";

        return css;
    }
}

let css = new CssClass("block");
css.setStyle("width", "300px");
css.setStyle("margin", "10px");

console.log(css.getCss());

css.removeStyle("margin");

console.log(css.getCss());


class HtmlBlock {
    constructor() {
        this.styles = [];
        this.root = null;
    }

    addStyle(style) {
        this.styles.push(style);
    }

    setRoot(root) {
        this.root = root;
    }

    getCode() {
        let code = "<style>";

        for (let style of this.styles) {
            code += style.getCss();
        }

        code += "</style>";

        code += this.root.getHtml();

        return code;
    }
}

let blockStyle = new CssClass("block");
blockStyle.setStyle("width", "300px");
blockStyle.setStyle("margin", "10px");

let imageStyle = new CssClass("img");
imageStyle.setStyle("width", "100%");

let textStyle = new CssClass("text");
textStyle.setStyle("text-align", "justify");

let main = new HtmlElement("div");
main.setAttribute("id", "wrapper");

let block = new HtmlElement("div");
block.setAttribute("class", "block");

let h3 = new HtmlElement("h3", false, "What is Lorem Ipsum?");

let img = new HtmlElement("img", true);
img.setAttribute("class", "img");
img.setAttribute("src", "lipsum.jpg");
img.setAttribute("alt", "Lorem Ipsum");

let p = new HtmlElement(
    "p",
    false,
    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."
);

p.setAttribute("class", "text");

let a = new HtmlElement("a", false, "More...");
a.setAttribute("href", "https://www.lipsum.com/");
a.setAttribute("target", "_blank");

p.appendChild(a);

block.appendChild(h3);
block.appendChild(img);
block.appendChild(p);

main.appendChild(block);

let htmlBlock = new HtmlBlock();

htmlBlock.addStyle(blockStyle);
htmlBlock.addStyle(imageStyle);
htmlBlock.addStyle(textStyle);

htmlBlock.setRoot(main);

document.write(htmlBlock.getCode());