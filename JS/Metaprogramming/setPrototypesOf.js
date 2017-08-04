Object.setPrototypesOf = function setPrototypesOf(obj1, ...rest){
    let proxyHandler = {
        get(target, key, ctx){
            if(Reflect.has(target,key)){
                return Reflect.get(target, key, ctx);
            } else {
                for(var proto of rest){
                    if(Reflect.has(proto, key)){
                        return Reflect.get(proto,key,ctx);
                    }
                }
            }
        }
    },
    proxy = new Proxy({}, proxyHandler);

    Object.setPrototypeOf(obj1,proxy);
}

let a = {};
let b = {
    b(){
        console.log('b');
    }
}

let c = {
    c(){
        console.log('c');
    }
}
Object.setPrototypesOf(a,b,c);
a.b();
a.c();