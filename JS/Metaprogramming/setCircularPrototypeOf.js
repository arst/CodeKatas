Object.setCircularPrototypeOf = function setCircularPrototypeOf(obj1, obj2){
    let proxyHandlers ={
        get(target, key, ctx){
            if(Reflect.has(target, key)){
                return Reflect.get(target, key, ctx);
            } else {
                return Reflect.get(this.source, key, ctx);
            }
        }
    },
    p1 = new Proxy({}, Object.assign(Object.create(proxyHandlers), {source: obj2})),
    p2 = new Proxy({}, Object.assign(Object.create(proxyHandlers), {source: obj1}));
    Object.setPrototypeOf(obj1,p1);
    Object.setPrototypeOf(obj2, p2);
};
let a = {
    name: 'a',
    foo() {
        console.log("Foo");
    }
}
let b = {
    name: 'b',
    boo() {
        console.log("Boo")
    }
}
Object.setCircularPrototypeOf(a,b);
a.boo();
b.foo();
b.zoo = function zoo(){
    console.log("Zoo");
}
a.zoo();
a.coo = function coo(){
    console.log("Coo")
}
b.coo();