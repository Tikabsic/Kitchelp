using Application.Interfaces;
using Application.Interfaces.InvitationService;
using Application.Interfaces.Repository;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services.InvitationService
{
    public class InvitationServiceHelper : IInvitationServiceHelper
    {
        private const string subject = "Kitchelp - New employee registration link.";
        private const string url = "https://Kitchelp.com/Invitation/";
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IEmailClient _emailClient;

        public InvitationServiceHelper(IRepositoryFactory repositoryFactory,
                                        IEmailClient emailClient)
        {
            _repositoryFactory = repositoryFactory;
            _emailClient = emailClient;
        }


        public async Task<bool> VerifyRequest(Guid restaurantId, Guid ownerId)
        {
            var restaurantRepository = _repositoryFactory.Create<Restaurant>();

            var restaurant = await restaurantRepository.GetByIdAsync(restaurantId);

            if (restaurant is null ||
                restaurant.OwnerId != ownerId)
            {
                throw new BadRequestException("Restaurant with given Id not exist.");
            }

            return true;
        }

        public async Task<string> GenerateInvitationToken(Guid restaurantId)
        {
            var numberOfDigits = 12;
            var chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var rng = new Random();
            var token = new char[numberOfDigits];

            for (int i = 0; i < numberOfDigits; i++)
            {
                token[i] = chars[rng.Next(chars.Length)];
            }

            var tokenId = token.ToString();

            var tokenRepository = _repositoryFactory.Create<InvitationToken>();

            var newToken = new InvitationToken()
            {
                RestaurantId = restaurantId,
                Token = tokenId
            };

            await tokenRepository.AddAsync(newToken);
            await tokenRepository.SaveChangesAsync();

            return newToken.Token;
        }

        public async Task SendInvitationEmail(string employeeEmail, string employeeName, string invitationToken)
        {
            var emailBody = $"Hello {employeeName}, here's your invitation link to register your new account to Kitchelp system: {url}+{invitationToken}";

            await _emailClient.SendEmailAsync(employeeEmail, subject, emailBody);
        }
    }
}
