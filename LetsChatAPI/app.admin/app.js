 var app = angular.module("customerManagement", ["ngRoute"]);
 var baseApiUrl = "http://localhost:57627/";
 var baseUrl = "http://localhost:57627/";
 
 var config = {
     headers: { 'Content-Type': 'application/json' }
 };

 app.config(function ($routeProvider) {
     
     $routeProvider
         .when("/customers",
             {
                 templateUrl: "/app.admin/customer/customerListView.html",
                 controller: "addNewcustomerController"
         })
         .when("/addCustomer",
             {
                 templateUrl: "/app.admin/customer/addNewCustomer.html",
                 controller: "addNewcustomerController"
             })
         .when("/editCustomer/:id",
             {
                 templateUrl: "/app.admin/customer/editCurrentCustomer.html",
                 controller: "editcustomerController"
             })
         .when("/preChatRequests",
             {
                 templateUrl: "/app.admin/chat/chatRequestListView.html",
                 controller: "chatController"
         })
         .when("/chat",
             {
                 templateUrl: "/app.admin/chat/adminchatWindow.html",
                 controller: "chatController"
             })
         .otherwise("/customers");
         });

// ********* Start of common module *******************

 

// ********* Start of common module *******************

// ********* Start of Customer module *******************
 
 app.controller('addNewcustomerController',
     function ($scope, $http, $location) {

         $scope.title = "Customer Management System";
         var processCustomerList = function(response) {
             $scope.customers = response.data;
         };
         var promoise = $http.get(baseApiUrl+"api/Customers").then(processCustomerList);
         $scope.customer = {
             customerId: 0,
             name: "name",
             address: "address",
             phoneNumber : "07448963549"
         };
         $scope.addNewCustomer = function (customer) {
             $http.post(baseApiUrl + "api/Customers", customer)
                 .success(function (data, status, headers, config) {

                     swal("Customer !", "New Customer Created Successfully!", "success");
                     $location.path(baseUrl +'Home/Index#/customers');
                 })
                 .error(function (data, status, header, config) {

                     swal("Customer !", "Due to Error!", "error");
                 });
         };
         $scope.deleteCustomer = function (customer) {

             swal({
                     title: "Are you sure?",
                     text: "You will not be able to recover this customer data!",
                     type: "warning",
                     showCancelButton: true,
                     confirmButtonColor: "#DD6B55",
                     confirmButtonText: "Yes",
                     closeOnConfirm: false
                 },
                 function () {

                     $http.delete(baseApiUrl + "api/Customers/" + customer.customerId, customer)
                         .success(function (data, status, headers, config) {

                             swal("Customer !", "Customer Has been delete!", "success");
                             $location.path(baseUrl + 'Home/Index#/customers');
                         })
                         .error(function (data, status, header, config) {

                             swal("Customer !", "Due to some Error we are not able to delete!", "error");
                         });
                 });
         };
         $scope.cancelAddNewCustomer = function() {

             $location.path(baseUrl + 'Home/Index#/customers');
         };
     });

 app.controller('editcustomerController',
     function ($scope, $http, $location, $routeParams) {

         $scope.title = "Customer Management System";
         var customerId = $routeParams.id;
         var processCustomerList = function (response) {
             $scope.customer = response.data;
         };

         var promoise = $http.get(baseApiUrl + "api/Customers/" + customerId).then(processCustomerList);

         $scope.updateCustomer = function (customer) {

             $http.put(baseApiUrl + "api/Customers/" + customer.customerId, customer)
                 .success(function (data, status, headers, config) {

                     swal("Customer !", "Customer Updated Successfully!", "success");
                     $location.path(baseUrl + 'Home/Index#/customers');
                 })
                 .error(function (data, status, header, config) {

                     swal("Customer !", "Error during update of Customer!", "error");
                 });

         };

         $scope.cancelEditCustomer = function(customer) {

             $location.path(baseUrl + 'Home/Index#/customers');
         };


     });
// ********* End of Customer module *******************


 // ********* Start of chat module *******************

 app.controller('chatController',
     function ($scope, $http, $location, $timeout) {

         $scope.title = "Chat Controller";
         var currentChatRequestList = function (response) {
             $scope.preChatRequests = response.data;
         };
         var promoise = $http.get(baseApiUrl + "api/ChatRequests").then(currentChatRequestList);

         $scope.startChat = function (preChatRequest) {
             location.replace(baseUrl + "Home/Index#/chat");
         };
     });


 app.controller('startChatController',
     function ($scope, $http, $location) {

         $scope.title = "Start Chat Controller";

         $scope.startConversation = function () {
             //$location.path(baseUrl + 'Home/Index#/customers');
         };
     });
// ********* End of Customer module *******************
