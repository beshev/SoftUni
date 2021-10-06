window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.getElementById('add');
    addButtonElement.addEventListener('click', onAddHandler)

    function onAddHandler(e) {
        e.preventDefault();
        let modelInputElement = document.getElementById('model');
        let yearInputElement = document.getElementById('year');
        let descInputElement = document.getElementById('description');
        let pricelInputElement = document.getElementById('price');
        let tbodyElement = document.getElementById('furniture-list');

        let model = modelInputElement.value;
        let year = Number.parseInt(yearInputElement.value);
        let desc = descInputElement.value;
        let price = Number(pricelInputElement.value);

        if (model.trim() == ''
            || desc.trim() == ''
            || isNaN(year) || year < 0 // !! Check if is for zero
            || isNaN(price) || price < 0) {
            return;
        }

        let tdModel = document.createElement('td');
        tdModel.textContent = model;

        let tdPrice = document.createElement('td');
        tdPrice.textContent = price.toFixed(2);

        let moreInfoButton = document.createElement('button');
        moreInfoButton.className = 'moreBtn';
        moreInfoButton.textContent = 'More Info';
        moreInfoButton.addEventListener('click', onMoreInfoHandler);

        let buyButton = document.createElement('button');
        buyButton.className = 'buyBtn';
        buyButton.textContent = 'Buy it';
        buyButton.addEventListener('click', onBuyHandler)

        let tdButtons = document.createElement('td');
        tdButtons.appendChild(moreInfoButton);
        tdButtons.appendChild(buyButton);

        let trInfo = document.createElement('tr');
        trInfo.className = 'info';
        trInfo.appendChild(tdModel);
        trInfo.appendChild(tdPrice);
        trInfo.appendChild(tdButtons);

        let trHide = document.createElement('tr');
        trHide.className = 'hide';

        let tdYear = document.createElement('td');
        tdYear.textContent = `Year: ${year}`;

        let tdDesc = document.createElement('td');
        tdDesc.setAttribute('colspan', '3');
        tdDesc.textContent = `Description: ${desc}`;

        trHide.appendChild(tdYear);
        trHide.appendChild(tdDesc);

        tbodyElement.appendChild(trInfo);
        tbodyElement.appendChild(trHide);

        modelInputElement.value = '';
        yearInputElement.value = '';
        descInputElement.value = '';
        pricelInputElement.value = '';

    }

    function onMoreInfoHandler(e) {
        let sibling = e.target.parentElement.parentElement.nextSibling;
        
        let style = sibling.style.display == 'contents' ? 'none' : 'contents';
        sibling.style.display = style;
        e.target.textContent = style == 'none' ? 'More Info' : 'Less Info';
    }


    function onBuyHandler(e) {
        let parent = e.target.parentElement.parentElement;
        let totalPriceElement = document.querySelector('table tfoot .total-price');
        let currentPriceElement = parent.children[1];

        let totalPrice = Number(totalPriceElement.textContent);
        let price = Number(currentPriceElement.textContent);

        totalPriceElement.textContent = (totalPrice + price).toFixed(2);

        parent.nextSibling.remove();
        parent.remove();
    }
}



