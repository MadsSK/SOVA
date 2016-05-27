var ns = ns || {};

ns.postbox = {
    subscribers: [],
    subscribe: function (callback, topic) {
        this.subscribers.push({ topic: topic, callback: callback });
    },
    notify: function (value, topic) {
        for (var i = 0; i < this.subscribers.length; i++) {
            if (this.subscribers[i].topic === topic) {
                this.subscribers[i].callback(value);
            }
        }
    }
};
