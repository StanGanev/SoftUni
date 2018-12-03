function solve(input) {
    let inventory = input[0].split(' ');
    for (let cmd of input) {
        if(cmd === 'Fight!') {
            break;
        }
        let commands = cmd.split(' ');
        if(commands[0] === 'Buy') {
            if(!inventory.includes(commands[1])) {
                inventory.push(commands[1]);
            }
        }
        if(commands[0] === 'Trash') {
            if(inventory.includes(commands[1])) {
                let indexOfItem = inventory.indexOf(commands[1]);
                inventory.splice(indexOfItem,1);
            }
        }
        if(commands[0] === 'Repair') {
            if(inventory.includes(commands[1])) {
                let indexOfItem = inventory.indexOf(commands[1]);
                inventory.splice(indexOfItem,1);
                inventory.push(commands[1]);
            }
        }
        if(commands[0] === 'Upgrade') {
            let item = commands[1].split('-');
            if(inventory.includes(item[0])) {
                let indexOfItem = inventory.indexOf(item[0]);
                let itemToInsert = item.join(':');
                inventory.splice(indexOfItem+1,0,itemToInsert);
            }
        }
    }
    let result = inventory.join(' ');
    console.log(result);
}