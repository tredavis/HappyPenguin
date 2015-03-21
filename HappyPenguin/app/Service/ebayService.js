happyApp.service('ebayService', ['$http', '$q', function ($http, $q) {
    var loadEbayDeferred = $q.defer();
    var items = [];
    var eItems = [];
    var search = function (input) {
        $http.jsonp('http://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findItemsByKeywords&SERVICE-VERSION=1.0.0&SECURITY-APPNAME=HappyPen-7825-4058-ade6-13df3b2db89c&GLOBAL-ID=EBAY-US&RESPONSE-DATA-FORMAT=json&callbackname=getEbay&REST-PAYLOAD&keywords=' + input + '&paginationInput.entriesPerPage=10&callback=JSON_CALLBACK')
            .success(function (data) {
                items = data.findItemsByKeywordsResponse[0].searchResult[0].item || [];
                itemsPrice = data.findItemsByKeywordsResponse[0].searchResult[0].item[0].sellingStatus[0].currentPrice[0] || [];
            eItems.length = 0;
                //loop through the data and create a new object to push to the controller.   
                ebayObject = new Object();
                for (var i = 0; i < 10; ++i)
                {              
                    
                    ebayObject = {
                        title: items[i].title[0],
                        image: items[i].galleryURL[0],
                        ebayLink: items[i].viewItemURL[0],
                        price: itemsPrice.__value__                     
                    }
                    eItems.push(ebayObject);
                   
                };
              
                
                loadEbayDeferred.resolve(eItems);
            }).error(function (data) {
                alert("the call didn't work");
            });

        return loadEbayDeferred.promise;

    }
    return {
        search: search
    }

}]);

