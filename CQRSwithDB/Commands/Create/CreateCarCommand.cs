using CQRSwithDB.Data;
using CQRSwithDB.Models;
using MediatR;

namespace CQRSwithDB.Commands.Create
{
    public class CreateCarCommand : IRequest<bool>
    {
        public CreateCarCommand(string brand, string model, DateTime productionDate, float mileage, float price)
        {
            Brand = brand;
            Model = model;
            ProductionDate = productionDate;
            Mileage = mileage;
            Price = price;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public float Mileage { get; set; }
        public float Price { get; set; }
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, bool>
    {
        private readonly CarContext _context;

        public CreateCarCommandHandler(CarContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var newCarToDatabase = new Car()
            {
                Brand = request.Brand,
                Model = request.Model,
                ProductionDate = request.ProductionDate,
                Mileage = request.Mileage,
                Price = request.Price
            };

            await _context.Cars.AddAsync(newCarToDatabase);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public class CreateCarRequest
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public float Mileage { get; set; }
        public float Price { get; set; }
    }
}
