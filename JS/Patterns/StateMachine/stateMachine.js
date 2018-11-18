const machine = {
    dispatch(actionName, ...payload) {
        const action = this.transitions[this.state][actionName];

        if (action) {
            action.apply(machine, ...payload);
        }
    },
    changeStateTo(newState) {
        this.state = newState;
    },
    state: "idle",
    transitions: {
        idle: {
            click: function() {
                this.changeStateTo('fetching');
                Promise.resolve('{}').then(data => {
                        try {
                            this.dispatch('success', JSON.parse(data));
                        } catch (error) {
                            this.dispatch('failure', error)
                        }
                    },
                    error => this.dispatch('failure', error)
                );
            }
        },
        fetching: {
            success: function() {
                this.changeStateTo('idle');
            },
            failure: function() {
                this.changeStateTo('error');
            }
        },
        error: {
            retry: function() {
                this.changeStateTo('idle');
                this.dispatch('click');
            }
        }
    }
};
